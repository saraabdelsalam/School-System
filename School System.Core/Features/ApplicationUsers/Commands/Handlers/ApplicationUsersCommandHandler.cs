using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using School_System.Core.Bases;
using School_System.Core.Features.ApplicationUsers.Commands.Models;
using School_System.Data.Entities;

namespace School_System.Core.Features.ApplicationUsers.Commands.Handlers
{
    public class ApplicationUsersCommandHandler : IRequestHandler<RegisterUserCommand, Response<string>>,
                                                  IRequestHandler<EditUserCommand, Response<string>>,
                                                  IRequestHandler<ChangeUserPasswordCommand, Response<string>>,
                                                  IRequestHandler<DeleteUserCommand, Response<string>>
    {
        #region Fields
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ResponseHandler _responseHandler;
        #endregion

        #region Constructors
        public ApplicationUsersCommandHandler(IMapper mapper, UserManager<ApplicationUser> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _responseHandler = new ResponseHandler();
        }
        #endregion

        #region Handlers
        public async Task<Response<string>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            // If Email exists
            var user = await _userManager.FindByEmailAsync(request.Email);
            if (user != null) return _responseHandler.BadRequest<string>("Email Exists");

            // If username exists
            var userByUserName = await _userManager.FindByNameAsync(request.UserName);
            if (userByUserName != null) return _responseHandler.BadRequest<string>("UserName Exists");

            // Mapping
            var identityUser = _mapper.Map<ApplicationUser>(request);
            // Create
            var createResult = await _userManager.CreateAsync(identityUser, request.Password);
            // Failed
            if (!createResult.Succeeded)
                return _responseHandler.BadRequest<string>(createResult.Errors.FirstOrDefault().Description);

            return _responseHandler.Created<string>("User Created Successfully");
        }
        public async Task<Response<string>> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var oldUser = await _userManager.FindByIdAsync(request.Id.ToString());
            if (oldUser == null) return _responseHandler.NotFound<string>();
            var newUser = _mapper.Map(request, oldUser);

            var userByUserName = await _userManager.Users.FirstOrDefaultAsync(x => x.UserName == newUser.UserName && x.Id != newUser.Id);
            if (userByUserName != null) return _responseHandler.BadRequest<string>("UserNameIsExist");

            var result = await _userManager.UpdateAsync(newUser);
            if (!result.Succeeded) return _responseHandler.BadRequest<string>("UpdateFailed");
            return _responseHandler.Success((string)"Updated Successfully");
        }

        public async Task<Response<string>> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return _responseHandler.NotFound<string>();
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) return _responseHandler.BadRequest<string>("Failed To Delete");
            return _responseHandler.Success((string)"Deleted Successfully");
        }

        public async Task<Response<string>> Handle(ChangeUserPasswordCommand request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByIdAsync(request.Id.ToString());
            if (user == null) return _responseHandler.NotFound<string>();
            var result = await _userManager.ChangePasswordAsync(user, request.CurrentPassword, request.NewPassword);
            if (!result.Succeeded) return _responseHandler.BadRequest<string>(result.Errors.FirstOrDefault().Description);
            return _responseHandler.Success("Password Changed Successfully");
        }
        #endregion
    }
}

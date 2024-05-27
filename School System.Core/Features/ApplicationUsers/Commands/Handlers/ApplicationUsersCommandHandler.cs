using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School_System.Core.Bases;
using School_System.Core.Features.ApplicationUsers.Commands.Models;
using School_System.Data.Entities;

namespace School_System.Core.Features.ApplicationUsers.Commands.Handlers
{
    public class ApplicationUsersCommandHandler : IRequestHandler<RegisterUserCommand, Response<string>>
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
        #endregion
    }
}

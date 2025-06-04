using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Abp.Authorization;
using Sekmen.OnlineExam.Authorization.Roles;
using Sekmen.OnlineExam.Authorization.Users;
using Sekmen.OnlineExam.MultiTenancy;
using Microsoft.Extensions.Logging;
using Abp.Domain.Uow;

namespace Sekmen.OnlineExam.Identity;

public class SecurityStampValidator(
    IOptions<SecurityStampValidatorOptions> options,
    AbpSignInManager<Tenant, Role, User> signInManager,
    ILoggerFactory loggerFactory,
    IUnitOfWorkManager unitOfWorkManager
) : AbpSecurityStampValidator<Tenant, Role, User>(options, signInManager, loggerFactory, unitOfWorkManager);
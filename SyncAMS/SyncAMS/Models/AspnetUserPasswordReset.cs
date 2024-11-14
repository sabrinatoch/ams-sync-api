using System;
using System.Collections.Generic;

namespace SyncAMS.Models;

public partial class AspnetUserPasswordReset
{
    public Guid PasswordResetToken { get; set; }

    public DateTime PasswordResetExpiration { get; set; }

    public Guid NetMembershipUser { get; set; }
}

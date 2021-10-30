using CoreLayer.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace CoreLayer.Utilities.Security.JWT
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaim> operationsClaims);
    }
}

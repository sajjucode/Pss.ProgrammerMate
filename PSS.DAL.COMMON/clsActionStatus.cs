using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSS.DAL.COMMON
{
    /// <summary>
    /// This class use to return different status of action that performed.
    /// </summary>
    /// <author>
    ///     Sajjucode
    /// </author>
    /// <CreatedDate>
    ///     Tuesday 10th June 2014
    /// </CreatedDate>
    public class clsActionStatus
    {
        public Boolean is_Error = false;
        public string Action_SuccessStatus = string.Empty;
        public string Action_FailureStatus = string.Empty;

        public string Return_Id { get; set; }
    }
}

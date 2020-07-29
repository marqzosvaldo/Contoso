using System.Collections.Generic;

namespace Contoso.Shared.Entities {
    public class RegisterResult {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
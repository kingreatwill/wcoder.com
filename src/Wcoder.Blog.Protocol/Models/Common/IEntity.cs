using System;
using System.Collections.Generic;
using System.Text;

namespace Wcoder.Blog.Protocol.Models
{
    public interface IEntity
    {
        long Id { get; set; }

        DateTime Created { get; set; }

        DateTime Updated { get; set; }

        bool Deleted { get; set; }
    }
}
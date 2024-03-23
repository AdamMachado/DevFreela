using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.ViewModels
{
    public class ProjectViewModel
    {
        public ProjectViewModel(string title,DateTime createAt)
        {
            Title = title;
            CreateAt = createAt;

        }
        public string Title { get; private set; }
        public DateTime CreateAt { get; private set; }
    }
}

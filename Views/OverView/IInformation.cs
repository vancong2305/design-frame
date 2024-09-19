using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignFrame.View.OverView
{
    internal interface IInformation
    {
        string Name { get; set; }
        string Class { get; set; }
        string Level { get; set; }
        string Avatar { get; set; }
        string Gen { get; set; }

        event EventHandler OnNameChanged;
        event EventHandler OnClassChanged;
        event EventHandler OnLevelChanged;
        event EventHandler OnGenChanged;
        event EventHandler OnAvatarChanged;
    }
}

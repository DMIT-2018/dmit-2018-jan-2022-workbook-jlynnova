using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinookSys.ViewModels
{
    public class PlaylistTrackMove
    {
        public int TrackId { get; set; }
        public int TrackNumber { get; set; }
        public bool SelectedTrack { get; set; }

        public string TrackInput { get; set; }
    }
}

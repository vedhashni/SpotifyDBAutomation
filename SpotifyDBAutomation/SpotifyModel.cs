using System;
using System.Collections.Generic;
using System.Text;

namespace SpotifyDBAutomation
{
    public class SpotifyModel
    {
        public int TrackId { get; set; }
        public int PlaylistId { get; set; }
        public string TrackName { get; set; }
        public string ArtistName { get; set; }
    }
}

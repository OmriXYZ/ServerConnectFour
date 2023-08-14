using System.ComponentModel.DataAnnotations;

namespace ServerConnectFour.Models
{
    public class Game
    {
        [Key]
        public int ID { get; set; } = default!;
        public int PlayerID { get; set; } = default!;
        public bool PlayerWin { get; set; } = default!;
        public DateTime GameDate { get; set; } = default!;
        public TimeSpan Duration { get; set; } = default!;
    }
}

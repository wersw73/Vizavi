using System.Collections.Generic;

namespace Chat.Models.Decanat {
    internal class Group {
        public string? Name { get; set; }

        public ICollection<Student>? Students { get; set; }

    }
}

using System.Collections.Generic;

namespace RoleplayCommands
{
    public class AnonCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class DoCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class EntornoCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class MeCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class OocCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class PoliciaCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class SamuCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class TwitterCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class StaffCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class MecanicoCommand
    {
        public string Prefix { get; set; }
        public string Text { get; set; }
    }

    public class Config
    {
        public AnonCommand Anon { get; set; }
        public DoCommand Do { get; set; }
        public EntornoCommand Entorno { get; set; }
        public MeCommand Me { get; set; }
        public OocCommand Ooc { get; set; }
        public PoliciaCommand Policia { get; set; }
        public SamuCommand Samu { get; set; }
        public TwitterCommand Twitter { get; set; }
        public StaffCommand Staff { get; set; }
        public MecanicoCommand Mecanico { get; set; }
    }
}

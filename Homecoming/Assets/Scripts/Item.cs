using System;

[Flags]
public enum Item
{
    None,
    Scarf   = 0x01,
    Leaf    = 0x02,
    Hat     = 0x04,
    Ticket  = 0x08,
    Money   = 0x10,
}

<Query Kind="Program" />

void Main()
{
    foreach (byte i in Enum.GetValues(typeof(Fooa)))
    {
        i.Dump();
    }

    new String(Enumerable.Repeat('-', 20).ToArray()).Dump();
    
    foreach (string name in Enum.GetNames(typeof(Fooa)))
    {
        name.Dump();
    };
}

// Define other methods and classes here





public enum Fooa : byte
{
    a,
    b,
    c,
    d,
    e,
    f,
    g,
    h,
    i,
    j,
    k,
    l,
    m,
    n,
    o,
    p,
    q,
    r,
    s,
    t,
    u,
    v,
    w,
    x,
    y,
    z,
    A,
    B,
    C,
    D,
    E,
    F,
    G,
    H,
    I,
    J,
    K,
    L,
    M,
    N,
    O,
    P,
    Q,
    R,
    S,
    T,
    U,
    V,
    W,
    X,
    Y,
    Z
}
<Query Kind="Program" />

//https://medium.com/@iliasshaikh/the-magic-of-c-closures-9c6e3fff6ff9

void Main()
{
    //CaptureScope();
    FaultyLoop();
    Console.WriteLine();
    FaultyLoopFixed();
}

#region some notes
/*

According to Wikipedia -

    In programming languages, closures (also lexical closures or function closures) 
    are a technique for implementing lexically scoped name binding in languages with 
    first-class functions. Operationally, a closure is a record storing a function 
    together with an environment : a mapping associating each free variable of the 
    function (variables that are used locally, but defined in an enclosing scope) 
    with the value or storage location to which the name was bound when the closure 
    was created. A closure — unlike a plain function — allows the function to access 
    those captured variables through the closure’s reference to them, even when the 
    function is invoked outside their scope.


my thought: it's almost like a way to "wrap" value type variables and have them behave, 
in a controlled manner, like reference type variables


*********

"Another thing to note from the implementation is that 
closures capture the ‘variable’ and not the ‘value’. 
Let’s update our original code slightly to see what the 
implication of this is. In the following code, we increment 
the value of I after the lambda has been defined."

(see CaptureScope())

*********

FaultyLoop() illustrates how the anonymous method behaves
when the free variable is changed prior to the exection of
the method i.e. the method's use of the free variable depends 
on the variable's current value at the time of execution, 
not the time of definition, essentially treating the variable
like a reference type variable.

FaultyLoopFixed() addresses this by declaring a (value type) 
variable inside the loop and using that variable to define
the anonymous method. When the method is executed, it uses 
the (value) variable that was in scope when the instance of 
the Action was defined.

*/
#endregion

void FaultyLoop()
{
    Action[] acts = new Action[10];
    for (int i = 0; i < 10; i++)
    {
        acts[i] = () => Console.Write(i + " ");
    }

    foreach (var a in acts)
    {
        a();
    }
}


void FaultyLoopFixed()
{
    Action[] acts = new Action[10];
    for (int i = 0; i < 10; i++)
    {
        int j = i; // introduce a local variable inside the loop block
        acts[i] = () => Console.Write(j + " ");
    }

    foreach (var a in acts)
    {
        a();
    }
}

void CaptureScope()
{
    int i = 100;
    Action a = () => Console.Write($"{i} ");
    i++; // increment i after the lambda has been defined
    bar(a);  // (bar's part of the raw implementation below)
}



#region raw implementation of how a closure (might) function
class @AnonymousClass001
{
    internal int i;
    internal void @AnonymousMethod001()
    {
        Console.Write($"{i}");
    }
}
void Main_ish()
{
    var a = foo();
    bar(a);
}
public Action foo()
{
    int i = 100;
    var r = new @AnonymousClass001();
    r.i = i;
    Action a = r.AnonymousMethod001;
    return a;
}
public void bar(Action a)
{
    a();
}
#endregion
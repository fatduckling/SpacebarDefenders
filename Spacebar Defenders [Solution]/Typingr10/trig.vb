Public Module trig 
    Public Function sin(ByVal int As Double)
        ' sin function
        Return Math.Sin((int * Math.PI / 180.0))
    End Function
    Public Function sin1(ByVal int As Double)
        'sin inverse function
        Return (Math.Asin(int)) * (180.0 / Math.PI)
    End Function
    Public Function tan(ByVal int As Double)
        'tan function
        Return Math.Tan((int * Math.PI / 180.0))
    End Function
    Public Function tan1(ByVal int As Double)
        'tan inverse function
        Return (Math.Atan(int)) * (180.0 / Math.PI)
    End Function
    Public Function cos(ByVal int As Double)
        'cos function
        Return Math.Cos((int * Math.PI / 180.0))
    End Function
    Public Function cos1(ByVal int As Double)
        'cos inverse function
        Return (Math.Acos(int)) * (180.0 / Math.PI)
    End Function
  

End Module

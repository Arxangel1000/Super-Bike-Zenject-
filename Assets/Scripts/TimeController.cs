using UnityEngine;

public class TimeController 
{
    public static void SetPauseOn()
    {
        Time.timeScale = 0;
    }
    
    public static void SetPauseOff()
    {
        Time.timeScale = 1;
    }
}

using UnityEngine;

public class TimeController 
{
    public void SetPauseOn()
    {
        Time.timeScale = 0;
    }
    
    public static void SetPauseOff()
    {
        Time.timeScale = 1;
    }
}

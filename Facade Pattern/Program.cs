using System;

namespace Facade_Pattern;

//'SubsystemA' class - a single unit of complex subsystem
public class Lights
{
    public void switchOnLights()
    {
        Console.WriteLine("Lights - Switched ON");
    }
    public void switchOffLights()
    {
        Console.WriteLine("Lights - Switched OFF");
    }
}
//'SubsystemB' class - a single unit of complex subsystem
public class MusicSystem
{
    public void switchOnMusicSystem()
    {
        Console.WriteLine("Music System - Switched ON");
    }
    public void switchOffMusicSystem()
    {
        Console.WriteLine("Music System - Switched OFF");
    }
}
//'SubsystemC' class - a single unit of complex subsystem
public class TV
{
    public void switchOnTV()
    {
        Console.WriteLine("TV - Switched ON");
    }
    public void switchOffTV()
    {
        Console.WriteLine("TV - Switched OFF");
    }
}
//'SubsystemD' class - a single unit of complex subsystem
public class HomeSecuritySystem
{
    public void EnableSecuritySystem()
    {
        Console.WriteLine("Security System - Enabled");
    }
    public void DisableSecuritySystem()
    {
        Console.WriteLine("Security System - Disabled");
    }
}

//'SubsystemE' class - a single unit of complex subsystem
public class PhoneAnsweringSystem
{
    public void SetHomeMessage()
    {
        Console.WriteLine("Phone Answering System - Home custom Message set");
    }
    public void SetAwayMessage()
    {
        Console.WriteLine("Phone Answering System - Away custom Message set");
    }
}
//'Facade' class - will provide interface for client to access complex subsystem
public class HomeFacade
{
    Lights light;
    MusicSystem musicSystem;
    TV tv;
    HomeSecuritySystem securitySystem;
    PhoneAnsweringSystem phoneAnsweringSystem;
    //constructor of facade class that will instantiate required subsystems
    public HomeFacade()
    {
        light = new Lights();
        musicSystem = new MusicSystem();
        tv = new TV();
        securitySystem = new HomeSecuritySystem();
        phoneAnsweringSystem = new PhoneAnsweringSystem();
    }
    //'operation in facade class'
    public void LeaveHomeforOffice()
    {
        light.switchOffLights();
        musicSystem.switchOffMusicSystem();
        tv.switchOffTV();
        securitySystem.EnableSecuritySystem();
        phoneAnsweringSystem.SetAwayMessage();
    }
    // 'Operation' in Facade class
    public void ArriveHomefromOffice()
    {
        light.switchOnLights();
        musicSystem.switchOnMusicSystem();
        tv.switchOnTV();
        securitySystem.DisableSecuritySystem();
        phoneAnsweringSystem.SetHomeMessage();
    }
}
//'Client' class
class Program
{
    static void Main(string[] args)
    {
        HomeFacade homeFacade = new HomeFacade();
        Console.WriteLine("--------------- Leave Home for Office Control----------------");
        homeFacade.LeaveHomeforOffice();
        Console.WriteLine("--------------- Arrive Home From Office Control----------------");
        homeFacade.ArriveHomefromOffice();
        Console.ReadLine();
    }
}
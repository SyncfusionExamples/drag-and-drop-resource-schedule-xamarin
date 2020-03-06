# How to get dropped resource in Xamarin.Forms Schedule (SfSchedule)?
You can get the dropped resource of SfSchedule in Xamarin.Forms using DropResourceItem in the [AppointmentDrop](https://help.syncfusion.com/cr/cref_files/xamarin/Syncfusion.SfSchedule.XForms~Syncfusion.SfSchedule.XForms.SfSchedule~AppointmentDrop_EV.html) event.

**XAML**
``` xml
<syncfusion:SfSchedule
                x:Name="schedule"
                AllowAppointmentDrag="true"
                ScheduleView="TimelineView" 
                DataSource="{Binding Events}"
                ScheduleResources="{Binding Employees}"
                SelectedResources="{Binding SelectedEmployees}"
                ShowResourceView="True"
                ResourceViewMode="Absolute"/>
```
**C#**
``` C#
public class SchedulerPageBehavior : Behavior<ContentPage>
{
    SfSchedule schedule;

    private void WireEvents()
    {
        this.schedule.AppointmentDrop += Schedule_AppointmentDrop;
    }

    private void Schedule_AppointmentDrop(object sender, AppointmentDropEventArgs e)
    {
        var changedResource = e.DropResourceItem;
        App.Current.MainPage.DisplayAlert("", "Resorce change into " + (changedResource as Employee).Name, "ok");
    }

    private void UnWireEvents()
    {
        this.schedule.AppointmentDrop -= Schedule_AppointmentDrop;
    }
}
```

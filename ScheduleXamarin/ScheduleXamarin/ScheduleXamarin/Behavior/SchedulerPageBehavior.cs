using Syncfusion.SfSchedule.XForms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace ScheduleXamarin
{
    public class SchedulerPageBehavior : Behavior<ContentPage>
    {
        SfSchedule schedule;
        protected override void OnAttachedTo(ContentPage bindable)
        {
            base.OnAttachedTo(bindable);
            this.schedule = bindable.Content.FindByName<SfSchedule>("schedule");
            this.WireEvents();
        }

        private void WireEvents()
        {
            this.schedule.AppointmentDrop += Schedule_AppointmentDrop;
        }

        private void Schedule_AppointmentDrop(object sender, AppointmentDropEventArgs e)
        {
            var changedResource = e.DropResourceItem;
            App.Current.MainPage.DisplayAlert("", "Resorce change into " + (changedResource as Employee).Name, "ok");
        }

        protected override void OnDetachingFrom(ContentPage bindable)
        {
            base.OnDetachingFrom(bindable);
            this.UnWireEvents();
        }

        private void UnWireEvents()
        {
            this.schedule.AppointmentDrop -= Schedule_AppointmentDrop;
        }
    }
}

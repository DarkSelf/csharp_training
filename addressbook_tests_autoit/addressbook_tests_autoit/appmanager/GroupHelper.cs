using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace addressbook_tests_autoit
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITTLE = "Group editor";
        public static string DELETEGROUPWINTITTLE = "Delete group";
        
        public GroupHelper(ApplicationManager manager) : base(manager) { }



        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            OpenGroupsDialogue();
            string count = aux.ControlTreeView(
                GROUPWINTITTLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetItemCount", "#0", "");
            for (int i = 0; i <  int.Parse(count); i++)
            {
               string item = aux.ControlTreeView(
                GROUPWINTITTLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "GetText", "#0|#"+i, "");
                list.Add(new GroupData()
                {
                    Name = item
                });
            }
            CloseGroupsDialogue();
            return list;
        }

        //public void Remove()
        //{
        //    OpenGroupsDialogue();
        //    aux.ControlTreeView(
        //        GROUPWINTITTLE, "", "WindowsForms10.SysTreeView32.app.0.2c908d51", "Select", "#1", "");
        //    aux.ControlClick(GROUPWINTITTLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
        //    aux.WinWait(DELETEGROUPWINTITTLE);
        //    aux.WinActivate(DELETEGROUPWINTITTLE);
        //    aux.WinActive(DELETEGROUPWINTITTLE);

        //    aux.ControlClick(GROUPWINTITTLE, "", "WindowsForms10.BUTTON.app.0.2c908d51");
        //    CloseGroupsDialogue();
        //}

        public void Add(GroupData newGroup)
        {
            OpenGroupsDialogue();
            aux.ControlClick(GROUPWINTITTLE, "", "WindowsForms10.BUTTON.app.0.2c908d53");
            aux.Send(newGroup.Name);
            aux.Send("{ENTER}");

            CloseGroupsDialogue();
        }

        private void CloseGroupsDialogue()
        {
            aux.ControlClick(GROUPWINTITTLE, "", "WindowsForms10.BUTTON.app.0.2c908d54");
        }

        private void OpenGroupsDialogue()
        {
            manager.Aux.ControlClick(WINTITTLE, "", "WindowsForms10.BUTTON.app.0.2c908d512");
            aux.WinWait(GROUPWINTITTLE);
            aux.WinActivate(GROUPWINTITTLE);
            aux.WinActive(GROUPWINTITTLE);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.InputDevices;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;
using System.Windows.Automation;


namespace Addressbook_tests_white
{
    public class GroupHelper : HelperBase
    {
        public static string GROUPWINTITTLE = "Group editor";
        
        public GroupHelper(ApplicationManager manager) : base(manager) { }



        public List<GroupData> GetGroupList()
        {
            List<GroupData> list = new List<GroupData>();
            Window dialogue = OpenGroupsDialogue();
            Tree tree = dialogue.Get<Tree>("uxAddressTreeView");
            TreeNode root = tree.Nodes[0];
            foreach (TreeNode item in root.Nodes)
            {
                list.Add(new GroupData()
                {
                    Name = item.Text
                });
            }

            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Remove(GroupData group)
        {
            Window dialogue = OpenGroupsDialogue();
            TreeNode treeNode = (TreeNode)dialogue.Get(SearchCriteria.ByText(group.Name));
            treeNode.Select();
            OpenDeleteDialogue();

            //Подтверждение удаления
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);

            CloseGroupsDialogue(dialogue);
        }


        public void Add(GroupData newGroup)
        {
            Window dialogue = OpenGroupsDialogue();
            manager.MainWindow.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.Name);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
 

            CloseGroupsDialogue(dialogue);
        }

        public void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        public Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GROUPWINTITTLE);
        }

        public void OpenDeleteDialogue()
        {
            manager.MainWindow.Get<Button>("uxDeleteAddressButton").Click();
        }
    }
}
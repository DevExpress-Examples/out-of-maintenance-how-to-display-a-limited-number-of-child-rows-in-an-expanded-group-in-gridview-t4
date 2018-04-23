using DevExpress.Utils.Menu;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;

namespace DXApplication3
{
    class GroupHelper
    {
        private GridView view;
        private Dictionary<int, int> groupRows = new Dictionary<int, int>();
        public int VisibleNumber { get; set; }
        public GroupHelper(GridView view)
        {
            this.VisibleNumber = int.MaxValue;
            this.view = view;
            view.EndGrouping += View_EndGrouping;
            view.PopupMenuShowing += View_PopupMenuShowing;
            view.CustomDrawGroupRow += View_CustomDrawGroupRow;
        }
        private void View_EndGrouping(object sender, EventArgs e)
        {
            groupRows.Clear();
            var groupInfo = view.DataController.GroupInfo;
            foreach (var groupRowInfo in groupInfo)
            {
                if (!groupInfo.IsLastLevel(groupRowInfo) || groupRowInfo.ChildControllerRowCount <= VisibleNumber)
                    continue;
                groupRows[groupRowInfo.Handle] = groupRowInfo.ChildControllerRowCount;
                groupRowInfo.ChildControllerRowCount = VisibleNumber;
                if (groupRowInfo.Expanded) RefreshGroupRow(groupRowInfo.Handle);
            }
        }
        private void View_CustomDrawGroupRow(object sender, DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs e)
        {
            var info = e.Info as GridGroupRowInfo;
            if (!info.IsGroupRowExpanded || info.Level != view.GroupCount - 1 || !groupRows.ContainsKey(e.RowHandle))
                return;
            info.DrawMoreIcons = true;
            var text = " <color=LightSteelBlue>right-click to show all child rows</color>";
            if (!info.GroupText.EndsWith(text)) info.GroupText += text;
        }
        private void View_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (e.HitInfo.HitTest != GridHitTest.Row || !e.HitInfo.InGroupRow) return;
            var rowHandle = e.HitInfo.RowInfo.RowHandle;
            if (!e.HitInfo.RowInfo.IsGroupRowExpanded || view.GetRowLevel(rowHandle) != view.GroupCount - 1
                || (!groupRows.ContainsKey(rowHandle) && view.GetChildRowCount(rowHandle) <= VisibleNumber))
                return;
            var menuItem = groupRows.ContainsKey(rowHandle) ?
                new DXMenuItem("Show all child rows", showAll_Click) :
                new DXMenuItem("Show less child rows", showLess_Click);
            menuItem.Tag = rowHandle;
            e.Menu.Items.Add(menuItem);
        }

        private void showLess_Click(object sender, EventArgs e)
        {
            var menuItem = sender as DXMenuItem;
            var rowHandle = (int)menuItem.Tag;
            var groupRowInfo = view.DataController.GroupInfo.GetGroupRowInfoByHandle(rowHandle);
            groupRows[groupRowInfo.Handle] = groupRowInfo.ChildControllerRowCount;
            groupRowInfo.ChildControllerRowCount = VisibleNumber;
            RefreshGroupRow(groupRowInfo.Handle);
        }

        private void showAll_Click(object sender, EventArgs e)
        {
            var menuItem = sender as DXMenuItem;
            var rowHandle = (int)menuItem.Tag;
            var groupRowInfo = view.DataController.GroupInfo.GetGroupRowInfoByHandle(rowHandle);
            groupRowInfo.ChildControllerRowCount = groupRows[rowHandle];
            groupRows.Remove(rowHandle);
            RefreshGroupRow(groupRowInfo.Handle);
        }
        private void RefreshGroupRow(int rowHandle)
        {
            view.DataController.CollapseRow(rowHandle);
            view.DataController.ExpandRow(rowHandle);
        }
    }
}

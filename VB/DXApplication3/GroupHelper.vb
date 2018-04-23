Imports DevExpress.Utils.Menu
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System
Imports System.Collections.Generic

Namespace DXApplication3
    Friend Class GroupHelper
        Private view As GridView
        Private groupRows As New Dictionary(Of Integer, Integer)()
        Public Property VisibleNumber() As Integer
        Public Sub New(ByVal view As GridView)
            Me.VisibleNumber = Integer.MaxValue
            Me.view = view
            AddHandler view.EndGrouping, AddressOf View_EndGrouping
            AddHandler view.PopupMenuShowing, AddressOf View_PopupMenuShowing
            AddHandler view.CustomDrawGroupRow, AddressOf View_CustomDrawGroupRow
        End Sub
        Private Sub View_EndGrouping(ByVal sender As Object, ByVal e As EventArgs)
            groupRows.Clear()
            Dim groupInfo = view.DataController.GroupInfo
            For Each groupRowInfo In groupInfo
                If (Not groupInfo.IsLastLevel(groupRowInfo)) OrElse groupRowInfo.ChildControllerRowCount <= VisibleNumber Then
                    Continue For
                End If
                groupRows(groupRowInfo.Handle) = groupRowInfo.ChildControllerRowCount
                groupRowInfo.ChildControllerRowCount = VisibleNumber
                If groupRowInfo.Expanded Then
                    RefreshGroupRow(groupRowInfo.Handle)
                End If
            Next groupRowInfo
        End Sub
        Private Sub View_CustomDrawGroupRow(ByVal sender As Object, ByVal e As DevExpress.XtraGrid.Views.Base.RowObjectCustomDrawEventArgs)
            Dim info = TryCast(e.Info, GridGroupRowInfo)
            If (Not info.IsGroupRowExpanded) OrElse info.Level <> view.GroupCount - 1 OrElse (Not groupRows.ContainsKey(e.RowHandle)) Then
                Return
            End If
            info.DrawMoreIcons = True
            Dim text = " <color=LightSteelBlue>right-click to show all child rows</color>"
            If Not info.GroupText.EndsWith(text) Then
                info.GroupText += text
            End If
        End Sub
        Private Sub View_PopupMenuShowing(ByVal sender As Object, ByVal e As PopupMenuShowingEventArgs)
            If e.HitInfo.HitTest <> GridHitTest.Row OrElse (Not e.HitInfo.InGroupRow) Then
                Return
            End If
            Dim rowHandle = e.HitInfo.RowInfo.RowHandle
            If (Not e.HitInfo.RowInfo.IsGroupRowExpanded) OrElse view.GetRowLevel(rowHandle) <> view.GroupCount - 1 OrElse ((Not groupRows.ContainsKey(rowHandle)) AndAlso view.GetChildRowCount(rowHandle) <= VisibleNumber) Then
                Return
            End If
            Dim menuItem = If(groupRows.ContainsKey(rowHandle), New DXMenuItem("Show all child rows", AddressOf showAll_Click), New DXMenuItem("Show less child rows", AddressOf showLess_Click))
            menuItem.Tag = rowHandle
            e.Menu.Items.Add(menuItem)
        End Sub

        Private Sub showLess_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim menuItem = TryCast(sender, DXMenuItem)
            Dim rowHandle = CInt((menuItem.Tag))
            Dim groupRowInfo = view.DataController.GroupInfo.GetGroupRowInfoByHandle(rowHandle)
            groupRows(groupRowInfo.Handle) = groupRowInfo.ChildControllerRowCount
            groupRowInfo.ChildControllerRowCount = VisibleNumber
            RefreshGroupRow(groupRowInfo.Handle)
        End Sub

        Private Sub showAll_Click(ByVal sender As Object, ByVal e As EventArgs)
            Dim menuItem = TryCast(sender, DXMenuItem)
            Dim rowHandle = CInt((menuItem.Tag))
            Dim groupRowInfo = view.DataController.GroupInfo.GetGroupRowInfoByHandle(rowHandle)
            groupRowInfo.ChildControllerRowCount = groupRows(rowHandle)
            groupRows.Remove(rowHandle)
            RefreshGroupRow(groupRowInfo.Handle)
        End Sub
        Private Sub RefreshGroupRow(ByVal rowHandle As Integer)
            view.DataController.CollapseRow(rowHandle)
            view.DataController.ExpandRow(rowHandle)
        End Sub
    End Class
End Namespace

#!/usr/bin/python
# -*- coding: utf-8 -*-

import wx
import wx.grid as gridlib
 
########################################################################
class MyGrid(gridlib.Grid):
    """"""
 
    #----------------------------------------------------------------------
    def __init__(self, parent):
        """Constructor"""
        gridlib.Grid.__init__(self, parent)
        self.CreateGrid(12, 8)

        self.Bind(gridlib.EVT_GRID_CELL_CHANGED, self.OnCellChange)

        self.SetCellValue(1, 2, u'こんにちわ')
        self.Show()

    def OnCellChange(self, evt):
        print evt.GetRow()
        print evt.GetCol()


########################################################################
class MyForm(wx.Frame):
    """"""
 
    #----------------------------------------------------------------------
    def __init__(self):
        """Constructor"""
        wx.Frame.__init__(self, parent=None, title="An Eventful Grid")
        panel = wx.Panel(self)
 
        myGrid = MyGrid(panel)
 
        sizer = wx.BoxSizer(wx.VERTICAL)
        sizer.Add(myGrid, 1, wx.EXPAND)
        panel.SetSizer(sizer)
 
if __name__ == "__main__":
    app = wx.PySimpleApp()
    frame = MyForm().Show()
    app.MainLoop()

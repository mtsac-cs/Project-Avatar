using System.Windows.Input;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class AItem : IItem, ICommand
{
    public Sprite icon;
    public Sprite thumbnail;
    
    public event EventHandler CanExecuteChanged;

    public bool CanExecute(object parameter)
    {
        throw new NotImplementedException();
    }

    public void Equip()
    {
        throw new NotImplementedException();
    }

    public void Execute(object parameter)
    {
        throw new NotImplementedException();
    }

    public void Unequip()
    {
        throw new NotImplementedException();
    }
}

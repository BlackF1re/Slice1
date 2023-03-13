using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;
using Slice1.Models;

namespace Slice1;

public partial class MainWindow : Window
{
    private PostgresContext db;
    public MainWindow()
    {
        InitializeComponent();
        db = new PostgresContext();
        List<User> users = db.Users.ToList();
        UsersGrid.Items = users;
    }

    private void Add(object sender, RoutedEventArgs e)
    {
        // <Label Content="FIO"/>
        //     <TextBox Margin="5" Name="FioBox"/>
        //     <TextBox Margin="5" Name="DateOfBirthBox"/>
        //     <TextBox Margin="5" Name="PhoneBox"/>
        //     <TextBox Margin="5" Name="AddressBox"/>
        
        if (FioBox.Text != "" && BirthdayBox.Text != "" && PhoneBox.Text != "" && AddressBox.Text != "" && RoleBox.Text != "")
        {
            User user = new User(FioBox.Text, BirthdayBox.Text, PhoneBox.Text, AddressBox.Text, RoleBox.Text);
            db.Users.Add(user);
            db.SaveChanges();
            List<User> users = db.Users.ToList();
            UsersGrid.Items = users;
            FioBox.Text = "";
            BirthdayBox.Text = "";
            PhoneBox.Text = "";
            AddressBox.Text = "";
            RoleBox.Text = "";
        }
    }
    
    private void Edt(object sender, RoutedEventArgs e)
    {
        if (UsersGrid.SelectedItem is User user)
        {
            User pr = db.Users.FirstOrDefault(b => b.Id == user.Id);
            if (FioBox.Text != "") pr.Bitrhday = FioBox.Text;
            if (BirthdayBox.Text != "") pr.Phone = BirthdayBox.Text;
            if (PhoneBox.Text != "") pr.Address = PhoneBox.Text;
            if (AddressBox.Text != "") pr.Role = RoleBox.Text);
            db.SaveChanges();
            List<User> users = db.Users.ToList();
            UsersGrid.Items = users;
            FioBox.Text = "";
            BirthdayBox.Text = "";
            PhoneBox.Text = "";
            AddressBox.Text = "";
        }
    }
    
    private void Del(object sender, RoutedEventArgs e)
    {
        if (UsersGrid.SelectedItem is User user)
        {
            User pr = db.Users.FirstOrDefault(b=>b.Id == user.Id);
            db.Users.Remove(pr);
            db.SaveChanges();
            List<User> users = db.Users.ToList();
            UsersGrid.Items = users;
        }
    }

    private void AddRole(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void EdtRole(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }

    private void DelRole(object? sender, RoutedEventArgs e)
    {
        throw new NotImplementedException();
    }
}
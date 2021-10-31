﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessLayer;

namespace DataAccessLayer
{
    public interface IPresenter
    {
        IMainView mainView { get; set; }
        IAuthorizationView authorizationView { get; set; }
        IRegistrationView registrationView { get; set; }
        void CreateNewUser();
        bool UserAuthorization();
        bool UserRegistration();
        void UpdateUserData();
        void UpdateСategories();
        void LoadСategories();
        void UpdateElements();
        void LoadElements();
        bool CheckCategories();
        User SelectedUser { get; }
        void AddCategory();
    }
}
using LearningXamarin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace LearningXamarin
{
    public partial class ObservableCollection : ContentPage
    {  
        public ObservableCollection()
        {
            InitializeComponent();

            Users = new List<UserModel>();
            {
                Users.Add(new UserModel() 

                {   Name = "Day",
                    ImageUrl = "icon11.png" });
            }
            Users.Add(new UserModel()
            {   Name = "Day",
                ImageUrl = "icon12.png" });

            Users.Add(new UserModel()
            {
                Name = "Day",
                ImageUrl = "icon13.png" });

            Users.Add(new UserModel()
            {
                Name = "Day",
                ImageUrl = "icon14.png" });

            Users.Add(new UserModel()
            {
                Name = "Day",
                ImageUrl = "icon15.png" });

            Users.Add(new UserModel()
            {
                Name = "Day",
                ImageUrl = "icon16.png" });

            Users.Add(new UserModel()
            {
                Name = "Day",
                ImageUrl = "icon17.png" });

            Users.Add(new UserModel()
            {
                Name = "Day",
                ImageUrl = "icon18.png" });

            Users.Add(new UserModel()
            {
                Name = "Day",
                ImageUrl = "icon19.png" });

            Users.Add(new UserModel()
            {
                Name = "Day",
                ImageUrl = "icon20.png" });

            BindingContext = this;
        }
        public List<UserModel> Users
        {
            get;
            set;
        }
    }
}


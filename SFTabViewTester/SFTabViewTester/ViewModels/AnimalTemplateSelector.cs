using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SFTabViewTester.ViewModels
{
    public class AnimalTemplateSelector : DataTemplateSelector
    {
        public DataTemplate DogTemplate { get; set; }
        public DataTemplate CatTemplate { get; set; }
        public DataTemplate WhaleTemplate { get; set; }
        public DataTemplate SharkTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (item is CatObject)
            {
                return CatTemplate;
            }
            else if (item is DogObject)
            {
                return DogTemplate;
            }
            else if (item is WhaleObject)
            {
                return WhaleTemplate;
            }
            else if (item is SharkObject)
            {
                return SharkTemplate;
            }
            return null;
        }
    }
}
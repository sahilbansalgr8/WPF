using System; 
using System.Collections.Generic; 
using System.Windows; 
using System.Windows.Media.Animation; 
using System.Windows.Media.Imaging; 
 
namespace CSWPFAnimatedImage 
{ 
    /// <summary> 
    /// Interaction logic for Window1.xaml 
    /// </summary> 
    public partial class MainWindow : Window 
    { 
        public MainWindow() 
        { 
            InitializeComponent(); 
        } 
 
        int nextImageIndex; 
        List<BitmapImage> images = new List<BitmapImage>(); 
 
        private void Window_Loaded(object sender, RoutedEventArgs e) 
        { 
            // Initialize the images collection 
            images.Add(new BitmapImage(new Uri("Images/image1.jpg", UriKind.Relative))); 
            images.Add(new BitmapImage(new Uri("Images/image2.jpg", UriKind.Relative))); 
            images.Add(new BitmapImage(new Uri("Images/image3.jpg", UriKind.Relative))); 
            images.Add(new BitmapImage(new Uri("Images/image4.jpg", UriKind.Relative))); 
 
            nextImageIndex = 2; 
        } 
                
        private void VisbleToInvisible_Completed(object sender, EventArgs e) 
        { 
            // Change the source of the myImage1 to the next image to be shown  
            // and increase the nextImageIndex 
            this.myImage1.Source = images[nextImageIndex++]; 
 
            // If the nextImageIndex exceeds the top bound of the collection,  
            // get it to 0 so as to show the first image next time 
            if (nextImageIndex == images.Count) 
            { 
                nextImageIndex = 0; 
            } 
 
            // Get the InvisibleToVisible storyboard and start it 
            Storyboard sb = this.FindResource("InvisibleToVisible") as Storyboard; 
            sb.Begin(this); 
 
        } 
 
        private void InvisibleToVisible_Completed(object sender, EventArgs e) 
        { 
            // Change the source of the myImage2 to the next image to be shown 
            // and increase the nextImageIndex 
            this.myImage2.Source = images[nextImageIndex++]; 
 
            // If the nextImageIndex exceeds the top bound of the collection,  
            // get it to 0 so as to show the first image next time 
            if (nextImageIndex == images.Count) 
            { 
                nextImageIndex = 0; 
            } 
 
            // Get the VisibleToInvisible storyboard and start it 
            Storyboard sb = this.FindResource("VisibleToInvisible") as Storyboard; 
            sb.Begin(this); 
        }    
 
    } 
} 


   M S B A M L   `   `   `  ????B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.ViewsWpfApp1.Views  5      !    WpfApp1.Views.EmployeesView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Views     5      .??5	      ?   ? RowDefinitions  5
   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      .+?5   
   &   System.Windows.Controls.DataGrid  -   5        $??dataGridUsers??5   j   $??0??6   $??4??6       AutoGenerateColumns$ False??61   $??Center=?6M      CanUserResizeRows$ False??6?   ??6   ??  ?? Path$ LoadDataBinding?   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID??6A      Width5  /System.Windows.Controls.DataGridLengthConverter$	 110 6M      
IsReadOnly$
 True??6Y   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? $ id?6Y     5      $	 Ime??6I   $	 170 6V   $
 True??6b    6%   ?? $ 
first_name?6b     5      $ Prezime??6H   $	 170 6Y   $
 True??6e    6%   ?? $ 	last_name?6e     5      $ E-mail??6E   $	 200 6U   $
 True??6a    6%   ?? $ e_mail?6a     5      $ Tip zaposlenog??6I   $	 150 6a   $
 True??6m    6%   ?? $ 
staff_type?6m   5      ? 5   
   
???????$??4??6"   $??1??6/   .+?5      ?? $
??Left=?6   $??
293,31,0,0q?63   $
??Wrap=?6G   $??Unesite ID zaposlenog:??6[   $	??Top=?6y   ?? 5      -   5        	 ??Name$	 ViewDeleteIdBox??5      $
??Left=?6/   $??
424,29,0,0q?6J   
 ?? TextWrapping$

 Wrap=?6^   $	??Top=?6r   $??74??6?   ?? 5       -   5         ??Name$ ViewDeleteButton??5       $??Obriši zaposlenog??6/   $??Center=?6K   $??0,70,0,0q?6h   $	??Top=?6z   6?   5"      5$      5%      
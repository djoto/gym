   M S B A M L   `   `   `  ????B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:WpfApp1.ViewsWpfApp1.Views  5      !    WpfApp1.Views.ListUsersView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:WpfApp1.Views     5      .??5	      ?   ? RowDefinitions  5
   
   ?? 5      ?? 5      ?? 5      ?? 5      ?? 5      .+?5   
   &   System.Windows.Controls.DataGrid  -   5        $??dataGridUsers??5   j   $??0??6   $??4??6       AutoGenerateColumns$ False??61   $??Center=?6M      CanUserResizeRows$ False??6?   ??6   ??  ?? Path$ LoadDataBinding?   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID??6A      Width5  /System.Windows.Controls.DataGridLengthConverter$ 50 6M      
IsReadOnly$
 True??6X   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? $ id?6X     5      $	 Ime??6I   $	 100 6V   $
 True??6b    6%   ?? $ 
first_name?6b     5      $ Prezime??6H   $	 100 6Y   $
 True??6e    6%   ?? $ 	last_name?6e     5      $ E-mail??6E   $	 140 6U   $
 True??6a    6%   ?? $ e_mail?6a     5      $ Tip korisnika??6H   $	 100 6_   $
 True??6k    6%   ?? $ 	user_type?6k     5      $ Trajanje članstva??6N   $	 100 6i   $
 True??6u    6%   ?? $ membership_card?6u     5      $ Datum isteka??6J   $	 100 6`   $
 True??6l    6%   ?? $ expire_date?6l     5      $ Trenutno trenira??6O   $	 120 6i   $
 True??6u    6%   ?? $ at_gym_currently?6u   5      ? 5    
   
???????$??4??6"   $??1??6/   .+?5!      ?? $
??Left=?6   $??
293,31,0,0q?63   $
??Wrap=?6G   $??Unesite ID korisnika:??6[   $	??Top=?6x   ?? 5"      -   5        	 ??Name$	 ViewUpdateIdBox??5"      $
??Left=?6/   $??
424,29,0,0q?6J   
 ?? TextWrapping$

 Wrap=?6^   $	??Top=?6r   $??74??6?   ?? 5#      -   5         ??Name$ ViewUpdateButton??5#      $"??Pogledaj/Ažuriraj korisnika??6/   $??Center=?6U   $??0,70,0,0q?6r   $	??Top=?6?   6?   5%      5'      5(      
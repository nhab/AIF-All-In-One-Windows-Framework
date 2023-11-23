# Aif : All in one Framework for Windows forms application developement
## Features:
- Least coupling concerns 

- Plugable and reusable classes with no extra dependencies.

- Independent, Even At the function level. 
  
  For example,All Helper classes have Independent static functions.
  
## Libraries :

- **Libraries for working with pdf** files 

- **CSLOLib**: File and folders management library

- **Active directory** Users and roles Management

- Standalone **Users and roles management system**

## Helper Classes

- **DB Helper** for all Database operations

- **DB Metadata** for Filling listView and listboxes with Data table items

- **QueryBuilder Helper**

- **Dynamic form and toolbar Generators**

- **Helper classes for common windows controls** like listview,treeview,datagrid helpers

- **CredentialsFile helper**

- **DateTime Helper**

- **Directory, File and FTP/sFTP Helper**

-  **Zip Helper**

- **Cmd Helper**

- **Encription helper**

- **Office Helper** To save results into excel

- **Project Helper** to show a window form an assembley

- **Persian Helper** to convert date to jalali and georgian

- **Source grid helper**

- **String Helper**

- **Webservice helper**

## Controls for windows  :

- **Editable Grid** , **GridView**
Usage:
```
//Setting columns title and name:
gridView1.SetColumnNames(
	new string[]{"FirstName", "LastName","Company","E-mail"}
);

//Settings withs of columns
gridView1.SetColumnWidth("FirstName", 10); // sets the width of the column in font units
gridView1.SetColumnWidth("LastName", 10); // sets the width of the column in font units
gridView1.SetColumnWidth("Company", 15); // sets the width of the column in font units
gridView1.SetColumnWidth("E-mail", 20); // sets the width of the column in font units

gridView1.SizeToFitGrid();
//Add rows to ther grid:
gridView1.SetFullRow(
	2,
	new string[]{"John", "Doe", "Microsoft", "joe@aol.com"}
);
//Setting an specific cell:
gridView1.SetCell(4, "E-mail", "bob@hotmail.com");

// set color of text and cell
gridView1.SetCellColor(4, "E-mail", Color.Blue);
gridView1.SetCellTextColor(4, "E-mail", Color.Yellow);

// set color of text and cell
gridView1.SetCellColor(2, "Company", Color.BlueViolet);
gridView1.SetCellTextColor(2, "Company", Color.Coral);
```
- **GridList** , **ListviewGrid**

- **Custom color picker**, **Color palnel**

- **DateTime Range Picker**

- **MaskedEditBox**, **Extende Textbox**

- **HoverButton**

- **ComboboxEX**

- **Folder selection contro**

- **Custom dialogs**

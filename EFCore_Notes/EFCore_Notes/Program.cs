using EFCore_Notes;
using EFCore_Notes.Data;
using EFCore_Notes.Models;
using EFCore_Notes.Service;
using EFCore_Notes.UI;

using var notesContext = new NotesContext();
var unitOfWork = new UnitOfWork(notesContext);
var userService = new UserService(unitOfWork);

MenuService.MainMenu(unitOfWork, userService);
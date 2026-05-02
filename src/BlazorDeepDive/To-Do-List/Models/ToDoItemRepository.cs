namespace To_Do_List.Models
{
    public static class ToDoItemRepository
    {
        private static List<ToDoItem> _toDoItems = new List<ToDoItem>()
        {
            new ToDoItem() { Id = 1, Name = "Learn Blazor", IsCompleted = false },
            new ToDoItem() { Id = 2, Name = "Build a Blazor app", IsCompleted = false },
            new ToDoItem() { Id = 3, Name = "Deploy the app", IsCompleted = false },
            new ToDoItem() { Id = 4, Name = "Celebrate", IsCompleted = false }
        };

        public static void AddToDoItem(ToDoItem item)
        {
            if(_toDoItems.Count > 0)
            {
                var maxId = _toDoItems.Max(i => i.Id);
                item.Id = maxId + 1;
                _toDoItems.Add(item);
            }
            else
            {
                item.Id = 1;
                _toDoItems.Add(item);
            }
        }

        public static List<ToDoItem> GetToDoItems()
        {
            return _toDoItems.OrderBy(i => i.IsCompleted).ThenByDescending(i => i.Id).ToList();
        }

        public static ToDoItem? GetToDoItemById(int id)
        {
            var item = _toDoItems.FirstOrDefault(i => i.Id == id);

            if(item != null)
            {
                return new ToDoItem() { Id = item.Id, Name = item.Name };
            }

            return null;
        }

        public static void UpdateToDoItem(int itemId, ToDoItem item)
        {
            if (itemId != item.Id) return;

            var existingItem = _toDoItems.FirstOrDefault(i => i.Id == item.Id);
            if(existingItem != null)
            {
                existingItem.Name = item.Name;
            }
        }

        public static void DeleteToDoItem(int itemId)
        {
            var item = _toDoItems.FirstOrDefault(i => i.Id == itemId);
            if(item != null)
            {
                _toDoItems.Remove(item);
            }
        }

        public static List<ToDoItem> SearchItems(string itemFilter)
        {
            return _toDoItems.Where(i => i.Name.Contains(itemFilter, StringComparison.OrdinalIgnoreCase)).ToList();
        }
    }
}

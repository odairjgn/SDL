namespace SDL.Services.Utils
{
    public static class FormsUtils
    {
        private const int ScrollOffsetResponsiveItem = 24;

        public static Form? FindForm(Control? child)
        {
            if (child == null)
            {
                return null;
            }

            return child is Form f ? f : FindForm(child.Parent);
        }

        public static void ResponsiveItemResize(Control control)
        {
            if (control.Parent == null)
            {
                return;
            }

            control.Width = control.Parent.Width - ScrollOffsetResponsiveItem;
        }
    }
}

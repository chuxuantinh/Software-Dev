﻿namespace ConstrainingGenerics
{
    public class TemplateClassConstrainedByEmptyConstructor<T>
        where T : new()
    {
        private T data;

        public TemplateClassConstrainedByEmptyConstructor()
        {
            this.data = new T();
        }
    }
}

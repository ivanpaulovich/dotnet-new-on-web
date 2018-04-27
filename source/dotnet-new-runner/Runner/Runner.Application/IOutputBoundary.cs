﻿namespace Runner.Application
{
    public interface IOutputBoundary<T>
    {
        T Output { get; }
        void Populate(T response);
    }
}

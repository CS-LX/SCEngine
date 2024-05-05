#pragma once

#include <iostream>
#include <Windows.h>
#include <msclr/marshal_cppstd.h>
#include <msclr/marshal.h>

using namespace System;
using namespace System::Diagnostics;
using namespace msclr::interop;
using namespace System::Runtime::InteropServices;
using namespace msclr::interop;

namespace SCEngine
{
    public ref class CPP//C++原生方法封装为C#
    {
    public:
        static IntPtr^ GetParentS(IntPtr^ window)
        {
            HWND hwnd = (HWND)window->ToInt32();
            return IntPtr(GetParent(hwnd));
        }

        static IntPtr FindWindowS(String^ name)
        {
            const wchar_t* windowName = (const wchar_t*)(Marshal::StringToHGlobalUni(name)).ToPointer();
            HWND window;
            window = FindWindow(windowName, NULL);
            return IntPtr(window);
        }

        static void SystemS(String^ command)
        {
            std::string commandStr = msclr::interop::marshal_as<std::string>(command);

            system(commandStr.c_str());
        }

        static void SetParentS(IntPtr^ parent, IntPtr^ child)
        {
            SetParent((HWND)child->ToInt32(), (HWND)parent->ToInt32());
        }
    };
}
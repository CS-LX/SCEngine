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
    public ref class WindowHandlerUtils
    {
    public:
        static array<IntPtr^>^ GetWindowsHandle(array<Process^>^ processes)
        {
            array<IntPtr^>^ handles = gcnew array<IntPtr^>(processes->Length);
            int count = 0;
            for each (Process ^ process in processes) {
                if (!String::IsNullOrEmpty(process->MainWindowTitle))
                {
                    handles[count++] = process->MainWindowHandle;
                }
            }
            return handles;
        }

        static IntPtr^ GetWindowsHandle(Process^ process)
        {
            if (!String::IsNullOrEmpty(process->MainWindowTitle))\
            {
                return process->MainWindowHandle;
            }
            return IntPtr::Zero;
        }

        static IntPtr FindWindowByName(String^ name)
        {
            const wchar_t* windowName = (const wchar_t*)(Marshal::StringToHGlobalUni(name)).ToPointer();
            HWND window;
            window = FindWindow(windowName, NULL);
            return IntPtr(window);
        }

        static void HideTargetWindow(String^ name)
        {
            const wchar_t* windowName = (const wchar_t*)(Marshal::StringToHGlobalUni(name)).ToPointer();
            HWND window;
            window = FindWindow(windowName, NULL);
            ShowWindow(window, SW_HIDE);//隐藏
        }

        static void ShowTargetWindow(String^ name)
        {
            const wchar_t* windowName = (const wchar_t*)(Marshal::StringToHGlobalUni(name)).ToPointer();
            HWND window;
            window = FindWindow(windowName, NULL);
            ShowWindow(window, SW_SHOW);//显示
        }

        static void RunSystemCommand(String^ command)
        {
            std::string commandStr = msclr::interop::marshal_as<std::string>(command);

            system(commandStr.c_str());
        }
    };
}

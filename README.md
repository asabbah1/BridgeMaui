# BridgeMaui
 MAUI iOS is not working properly after it is delivered to Appstore, or TestFlight #12353 
 https://github.com/dotnet/maui/issues/12353
 
 # Crash Details TestFlight
 ```
 Incident Identifier: C2FA021A-7B08-4086-8487-9AEDD68F2270
Hardware Model:      iPhone10,6
Process:             Bridge [13781]
Path:                /private/var/containers/Bundle/Application/B64DA516-5D7D-46B5-9B47-956DD8B13941/Bridge.app/Bridge
Identifier:          com.jobridge.bridge
Version:             4.1 (6.4)
AppStoreTools:       14C17
AppVariant:          1:iPhone10,6:16
Beta:                YES
Code Type:           ARM-64 (Native)
Role:                Foreground
Parent Process:      launchd [1]
Coalition:           com.jobridge.bridge [1446]

Date/Time:           2023-01-01 17:15:16.9539 +0300
Launch Time:         2023-01-01 17:15:16.3004 +0300
OS Version:          iPhone OS 16.0 (20A362)
Release Type:        User
Baseband Version:    5.03.01
Report Version:      104

Exception Type:  EXC_CRASH (SIGABRT)
Exception Codes: 0x0000000000000000, 0x0000000000000000
Triggered by Thread:  0


Thread 0 name:
Thread 0 name:
Thread 0 Crashed:
0   libsystem_kernel.dylib        	0x00000001ff41c2f4 __pthread_kill + 8 (:-1)
1   libsystem_pthread.dylib       	0x000000020dfe4654 pthread_kill + 208 (pthread.c:1670)
2   libsystem_c.dylib             	0x00000001cdb01e9c abort + 124 (abort.c:118)
3   Bridge                        	0x0000000106d80664 0x1045b0000 + 41748068
4   Bridge                        	0x0000000106d0f808 mono_runtime_setup_stat_profiler + 41285640 (mini-posix.c:662)
5   libsystem_platform.dylib      	0x000000020df43c10 _sigtramp + 52 (sigtramp.c:116)
6   libsystem_pthread.dylib       	0x000000020dfe4654 pthread_kill + 208 (pthread.c:1670)
7   libsystem_c.dylib             	0x00000001cdb01e9c abort + 124 (abort.c:118)
8   Bridge                        	0x0000000106abe254 print_callback(char const*, int) + 38855252 (runtime.m:1173)
9   Bridge                        	0x0000000106d4956c monoeg_g_logv + 41522540 (goutput.c:173)
10  Bridge                        	0x0000000106d496a0 monoeg_g_log + 41522848 (goutput.c:184)
11  Bridge                        	0x0000000106cea280 load_aot_module + 41132672 (aot-runtime.c:2323)
12  Bridge                        	0x0000000106bdd6bc mono_assembly_request_load_from + 40031932 (assembly.c:2028)
13  Bridge                        	0x0000000106bdd1dc mono_assembly_request_open + 40030684 (assembly.c:1635)
14  Bridge                        	0x0000000106bdedd8 mono_assembly_open + 40037848 (assembly.c:1838)
15  Bridge                        	0x0000000106abd994 xamarin_open_and_register + 38853012 (runtime.m:1000)
16  Bridge                        	0x0000000106d4c5c0 xamarin_register_assemblies_impl() + 41534912 (main.arm64.mm:171)
17  Bridge                        	0x0000000106ac67a8 xamarin_main + 38889384 (monotouch-main.m:444)
18  Bridge                        	0x0000000106d4c7c0 main + 41535424 (main.arm64.mm:228)
19  dyld                          	0x00000001e365ade0 start + 2080 (dyldMain.cpp:1168)

Thread 1:
0   libsystem_pthread.dylib       	0x000000020dfd8674 start_wqthread + 0 (:-1)

Thread 2 name:
Thread 2:
0   libsystem_kernel.dylib        	0x00000001ff4169e0 __psynch_cvwait + 8 (:-1)
1   libsystem_pthread.dylib       	0x000000020dfd9584 _pthread_cond_wait$VARIANT$armv81 + 1220 (pthread_cond.c:636)
2   Bridge                        	0x0000000106cd4540 thread_func + 41043264 (sgen-thread-pool.c:198)
3   libsystem_pthread.dylib       	0x000000020dfda060 _pthread_start + 116 (pthread.c:893)
4   libsystem_pthread.dylib       	0x000000020dfd8688 thread_start + 8 (:-1)


Thread 0 crashed with ARM Thread State (64-bit):
    x0: 0x0000000000000000   x1: 0x0000000000000000   x2: 0x0000000000000000   x3: 0x0000000000000000
    x4: 0xffffffff9b6f4e1f   x5: 0x0000000000000018   x6: 0x000000016b84e1d0   x7: 0x000000016b84d8c0
    x8: 0x00000002223f42c0   x9: 0xe8f2670d0b2a140b  x10: 0x3d3d3d3d3d3d3d3d  x11: 0x3d3d3d3d3d3d3d3d
   x12: 0x3d3d3d3d3d3d3d3d  x13: 0x3d3d3d3d3d3d3d3d  x14: 0x3d3d3d3d3d3d3d3d  x15: 0x0a3d3d3d3d3d3d3d
   x16: 0x0000000000000148  x17: 0x00000001c1f9f158  x18: 0x0000000000000000  x19: 0x0000000000000006
   x20: 0x0000000000000103  x21: 0x00000002223f43a0  x22: 0x0000000000000007  x23: 0x0000000000002788
   x24: 0x000000010711683c  x25: 0x0000000000000038  x26: 0x0000000000000268  x27: 0x0000000106fb7678
   x28: 0x0000000280bf2020   fp: 0x000000016b84e1e0   lr: 0x000000020dfe4654
    sp: 0x000000016b84e1c0   pc: 0x00000001ff41c2f4 cpsr: 0x40000000
   esr: 0x56000080  Address size fault


Binary Images:
0x1045b0000 - 0x106f67fff Bridge arm64  <54a691cb88bb3eda9a4daf73e135cdd3> /private/var/containers/Bundle/Application/B64DA516-5D7D-46B5-9B47-956DD8B13941/Bridge.app/Bridge
0x1cdae2000 - 0x1cdb5dfff libsystem_c.dylib arm64  <637814c516103a04b2544eb2b26b750b> /usr/lib/system/libsystem_c.dylib
0x1e3647000 - 0x1e36c0dcb dyld arm64  <39fb7cd57af23e3c9cefb214ddbc3353> /usr/lib/dyld
0x1ff415000 - 0x1ff44afff libsystem_kernel.dylib arm64  <f984bd5d5eb83894b57d307eab4e7b07> /usr/lib/system/libsystem_kernel.dylib
0x20df41000 - 0x20df4cfff libsystem_platform.dylib arm64  <d5407b3ff61c3a1d8a11c713f8a9e920> /usr/lib/system/libsystem_platform.dylib
0x20dfd7000 - 0x20dfe7fff libsystem_pthread.dylib arm64  <c505adfd68fb3e92aaa8af0ed030c66b> /usr/lib/system/libsystem_pthread.dylib

EOF
```

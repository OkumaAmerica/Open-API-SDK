[ TDG.Logging.dll 2.16.0.0 ]

  [ ~~~~~ Important ~~~~~ ]
    Modify the .NET 2.0 version first, then transfer changes
	to the .NET 4.0 version.
	
	
  [ Key ]
	[]  = new request
	[-] = not implemented request; will not add
	[/] = implemented, not tested
	[x] = fully implemented

    [Requirements]
		* .NET = 2.0
		* CPU  = ANY
		* Built in Visual Studio 2010
		* Requires applications to run with Administrative privileges; must be able to write to 
		  local directory
		* No THINC-API requirement

[ To Do ]
  [] add safety logging in case of dequeue worker fail; array is lost in this case
  [] build example code (vb.net & c#)
  [] add column for process id (implemented on csv; add to txt and sqlite)
  
[ Notes ]
  [2.16] add public member: Flush; immediately log all backlogged items
  [2.16] Added 'TestAllLogging' method to test project
  [2.16] XML is being serialized incorrectly
  [2.16] Removed Beta HSL
  [2.16] Implement 'Flush' function for the Queues
  [2.16] Added SetDefaultSyntax method
  [2.16] added constructor for user log type
  [2.16] cleaned up test project
  [2.16] Added USER_CSV LogFileType
  [-] add log file full path to evt information?
     would correct problem of multiple items in queue going to different files
	 when the full path is being changed externally
	 * might not be possible because of the way that the stream writer opens files
  [2.13] fixed 'tab' in default syntax before event guid
  [2.10] fixed WriteEventTime in hsl only
  [2.10] removed LogFileBaseName property from hsl
  [2.10] removed LoggingDirectory property from hsl
  [2.10] added LogFileFullPath property to hsl
  [2.10] added code to create logging directory if it does not exist (hsl only)
  [2.10] removed InitLogging function from hsl
  [2.9] added ShouldQuote property to the hsl
  [2.9] added WriteEventTime property to the hsl
  [x] add v2.7 to oku base project
  [2.7] ** noted extreme slow logging when using CSV (uses csv helper) on single core with OSP running
         ** this happens when running on the control only if the executable was built in Debug configuration.
		    not sure why.  If built in Release, there is no problem.
		 ** NOT a problem when using tdg.logging.systemeventlog directly; only when using the 'logging' Class in QuickScan
		 *  (disproved this) Happening if the Logging class uses Shared members; does not happen otherwise
		 *  tdg logging queue ends up logging to disk at 1s intervals (or so) and the app uses large amount of CPU time.
		 *  can duplicate on Dell PC (cpu ~ 10% instead of 80)
		 *  usually does not happen on the first attempt to log
		 *  can happen on all log types
		 *  can happen with both shared and instance members (not just shared, as above)
		 *  does not happen every time; logging may  be normal the  next time it's tried
		 ** does not seem to happen if using DequeueAll rather than DequeueChunk on the BlockingQueue
 		 ** fixed: changed DequeueChunk to be a Function that returns an Array of cEvent rather than a Sub that 
		    fills (byRef) an existing Array
  [2.7] fixed DequeueAll not generating log file	
  [2.7] fixed ThreadStartedCount not decreasing
  [2.4] fixed text log; event type was integer
  [2.4] add messagebox notification when dequeue worker fails
  [2.2] add sqlite to access okuma master exception log
  [2.2] expose custom syntax for text log entries
cc / 2014-11-05 // v2.2 commit
   ~ changed name of test app
cc / 2014-10-30 // v2.2 commit
cc / 2014-10-29 // initial commit to bitbucket
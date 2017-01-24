
   public class FileWatcher
   {
      private static readonly ILog log = LogManager.GetLogger(typeof(FileWatcher));
      private string _path;
      private string _filter;
      public event FileSystemEventHandler Changed;

      public FileWatcher(string path, string filter)
      {
         this.Filter = filter;
         this.Path = path;
         Watch();
      }

      public void Watch()
      {
         // establish the path to the directory to watch
         FileSystemWatcher watcher = new FileSystemWatcher();
         try
         {
            watcher.Path = this.Path;
         }
         catch (ArgumentException eArg)
         {
            log.Error("Caught exception in action event handler.  Rethrowing after logging", eArg);
         }

         //set up the things to be on the look out for.
         watcher.NotifyFilter = NotifyFilters.LastAccess
            | NotifyFilters.LastWrite
            | NotifyFilters.FileName
            | NotifyFilters.CreationTime
            | NotifyFilters.DirectoryName;

         // only watch for specified file types
         watcher.Filter = this.Filter;

         // add event handlers
         watcher.Created += new FileSystemEventHandler(OnChanged);
         //watcher.Deleted += new FileSystemEventHandler(OnChanged);
         watcher.Changed += new FileSystemEventHandler(OnChanged);
         watcher.EnableRaisingEvents = true;

      }

      protected virtual void OnChanged(object sender, FileSystemEventArgs e)
      {
         if (Changed != null)
            Changed(this, e);
      }

      public string Filter
      {
         get { return _filter; }
         set { _filter = value; }
      }


      public string Path
      {
         get { return _path; }
         set { _path = value; }
      }

   }

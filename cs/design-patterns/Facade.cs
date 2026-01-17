using System;

// Complex subsystems
class VideoFile
{
	public string FileName { get; }

	public VideoFile(string fileName)
	{
		FileName = fileName;
	}
}

class VideoCodec
{
	public void Convert(VideoFile videoFile, string format)
	{
		Console.WriteLine($"Converting video '{videoFile.FileName}' to format '{format}'");
		// Conversion logic goes here
	}
}

class AudioCodec
{
	public void Convert(VideoFile videoFile, string format)
	{
		Console.WriteLine($"Converting audio of video '{videoFile.FileName}' to format '{format}'");
		// Conversion logic goes here
	}
}

class MetadataExtractor
{
	public void Extract(VideoFile videoFile)
	{
		Console.WriteLine($"Extracting metadata from video '{videoFile.FileName}'");
		// Metadata extraction logic goes here
	}
}

// Facade
class VideoConversionFacade
{
	private VideoCodec videoCodec;
	private AudioCodec audioCodec;
	private MetadataExtractor metadataExtractor;

	public VideoConversionFacade()
	{
		videoCodec = new VideoCodec();
		audioCodec = new AudioCodec();
		metadataExtractor = new MetadataExtractor();
	}

	public void ConvertVideo(string fileName, string format)
	{
		VideoFile videoFile = new VideoFile(fileName);

		metadataExtractor.Extract(videoFile);
		videoCodec.Convert(videoFile, format);
		audioCodec.Convert(videoFile, format);

		Console.WriteLine($"Video conversion completed for file '{fileName}'");
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		VideoConversionFacade facade = new VideoConversionFacade();
		facade.ConvertVideo("video.mp4", "avi");
	}
}
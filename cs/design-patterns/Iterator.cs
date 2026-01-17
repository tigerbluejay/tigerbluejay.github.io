using System;
using System.Collections;
using System.Collections.Generic;

// Iterator interface
interface ISongIterator
{
	bool HasNext();
	Song Next();
}

// Aggregate interface
interface IPlaylist : IEnumerable<Song>
{
	ISongIterator GetIterator();
}

// Concrete Iterator
class SongIterator : ISongIterator
{
	private readonly List<Song> _songs;
	private int _position;

	public SongIterator(List<Song> songs)
	{
		_songs = songs;
		_position = 0;
	}

	public bool HasNext()
	{
		return _position < _songs.Count;
	}

	public Song Next()
	{
		Song song = _songs[_position];
		_position++;
		return song;
	}
}

// Concrete Aggregate
class Playlist : IPlaylist
{
	private readonly List<Song> _songs;

	public Playlist()
	{
		_songs = new List<Song>();
	}

	public void AddSong(Song song)
	{
		_songs.Add(song);
	}

	public ISongIterator GetIterator()
	{
		return new SongIterator(_songs);
	}

	public IEnumerator<Song> GetEnumerator() // this method is called by the method below
	{
		return _songs.GetEnumerator();
	}

	IEnumerator IEnumerable.GetEnumerator() // this is called when we run the foreach loop
	{
		return GetEnumerator(); // this calls the method above
	}
}

// Song class
class Song
{
	public string Title { get; set; }
	public string Artist { get; set; }

	public Song(string title, string artist)
	{
		Title = title;
		Artist = artist;
	}
}

// Client code
class Program
{
	static void Main(string[] args)
	{
		// Create a playlist
		var playlist = new Playlist();

		// Add songs to the playlist
		playlist.AddSong(new Song("Song 1", "Artist 1"));
		playlist.AddSong(new Song("Song 2", "Artist 2"));
		playlist.AddSong(new Song("Song 3", "Artist 3"));

		// Iterate over the playlist using iterator
		var iterator = playlist.GetIterator();
		while (iterator.HasNext())
		{
			Song song = iterator.Next();
			Console.WriteLine("Now playing: {0} by {1}", song.Title, song.Artist);
		}

		// Iterate over the playlist using foreach loop
		foreach (Song song in playlist)
		{
			Console.WriteLine("Now playing: {0} by {1}", song.Title, song.Artist);
		}
	}
}
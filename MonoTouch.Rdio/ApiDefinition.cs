using System;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;
using MonoTouch.ObjCRuntime;

namespace MonoTouch.Rdio
{
	[BaseType (typeof (NSObject))]
	interface Rdio {
		[Export ("delegate")]
		RdioDelegate Delegate { get; set;  }
		
		[Export ("user")]
		NSDictionary User { get;  }
		
		[Export ("player")]
		RDPlayer Player { get;  }
		
		[Export ("initWithConsumerKey:andSecret:delegate:")]
		NSObject InitWithConsumerKeyandSecretdelegate (string key, string secret, RdioDelegate del);
		
		[Export ("authorizeFromController:")]
		void AuthorizeFromController (UIViewController currentController);
		
		[Export ("authorizeUsingAccessToken:fromController:")]
		void AuthorizeUsingAccessTokenfromController (string accessToken, UIViewController currentController);
		
		[Export ("logout")]
		void Logout ();
		
		[Export ("callAPIMethod:withParameters:delegate:")]
		RDAPIRequest CallAPIMethodwithParametersdelegate (string method, NSDictionary param, RDAPIRequestDelegate del);
		
	}
	
	[BaseType (typeof (NSObject))]
	[Model]
	interface RdioDelegate {
		[Export ("rdioDidAuthorizeUser:withAccessToken:")]
		void RdioDidAuthorizeUserwithAccessToken (NSDictionary user, string accessToken);
		
		[Export ("rdioAuthorizationFailed:")]
		void RdioAuthorizationFailed (string error);
		
		[Export ("rdioAuthorizationCancelled")]
		void RdioAuthorizationCancelled ();
		
		[Export ("rdioDidLogout")]
		void RdioDidLogout ();
		
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface RDAPIRequestDelegateProtocol {
		[Abstract]
		[Export ("rdioRequest:didLoadData:")]
		void RdioRequestdidLoadData (RDAPIRequest request, NSObject data);
		
		[Abstract]
		[Export ("rdioRequest:didFailWithError:")]
		void RdioRequestdidFailWithError (RDAPIRequest request, NSError error);
		
	}
	
	[BaseType (typeof (NSObject))]
	interface RDAPIRequestDelegate : RDAPIRequestDelegateProtocol {
		[Export ("userInfo")]
		NSObject UserInfo { get; set;  }
		
		[Static]
		[Export ("delegateToTarget:loadedAction:failedAction:")]
		NSObject DelegateToTargetloadedActionfailedAction (NSObject target, Selector load, Selector fail);
		
		[Export ("initWithTarget:action:")]
		NSObject InitWithTargetaction (NSObject target, Selector action);
		
		[Export ("initWithTarget:loadedAction:failedAction:")]
		NSObject InitWithTargetloadedActionfailedAction (NSObject target, Selector load, Selector fail);
		
	}
	
	[BaseType (typeof (NSObject))]
	interface RDAPIRequest {
		[Export ("parameters")]
		NSDictionary Parameters { get;  }
		
		[Export ("cancel")]
		void Cancel ();
		
	}

	[BaseType (typeof (NSObject))]
	[Model]
	interface RDPlayerDelegate {
		[Abstract]
		[Export ("rdioIsPlayingElsewhere")]
		bool RdioIsPlayingElsewhere ();
		
		[Abstract]
		[Export ("rdioPlayerChangedFromState:toState:")]
		void RdioPlayerChangedFromStatetoState (RDPlayerState oldState, RDPlayerState newState);
		
		[Abstract]
		[Export ("rdioPlayerQueueDidChange")]
		void RdioPlayerQueueDidChange ();
		
	}
	
	[BaseType (typeof (NSObject))]
	interface RDPlayer {
		[Export ("state")]
		RDPlayerState State { get;  }
		
		[Export ("position")]
		double Position { get;  }
		
		[Export ("duration")]
		double Duration { get;  }
		
		[Export ("currentTrack")]
		string CurrentTrack { get;  }
		
		[Export ("currentTrackIndex")]
		int CurrentTrackIndex { get;  }
		
		[Export ("trackKeys")]
		NSArray TrackKeys { get;  }
		
		[Export ("delegate")]
		RDPlayerDelegate Delegate { get; set;  }
		
		[Export ("playSource:")]
		void PlaySource (string sourceKey);
		
		[Export ("playSources:")]
		void PlaySources (NSArray sourceKeys);
		
		[Export ("next")]
		void Next ();
		
		[Export ("previous")]
		void Previous ();
		
		[Export ("play")]
		void Play ();
		
		[Export ("playAndRestart:")]
		void PlayAndRestart (bool shouldRestart);
		
		[Export ("togglePause")]
		void TogglePause ();
		
		[Export ("stop")]
		void Stop ();
		
		[Export ("seekToPosition:")]
		void SeekToPosition (double positionInSeconds);
		
		[Export ("queueSource:")]
		void QueueSource (string sourceKey);
		
		[Export ("queueSources:")]
		void QueueSources (NSArray sourceKeys);
		
		[Export ("updateQueue:withCurrentTrackIndex:")]
		bool UpdateQueuewithCurrentTrackIndex (NSArray sourceKeys, int index);
		
	}
}


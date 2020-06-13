/*
 * Copyright (c) 2002, Papyrus Racing Games, Inc.
 * All rights reserved.
 *
 * Date			Who		What
 * 06-apr-02	RJC 	Created
 *
 * Description:
 *	A small test harness for the Papyrus telemetry system.
 *	It is the intent that you can place this file, along
 *	with papytelemapp.obj and papytelemapp.h in the same
 *	directory, and get a valid executable when you issue
 *		cl /W3 /MT tsample.cpp papytelemapp.obj
 *	(/W3 turns on DevStudio's second-highest warning level,
 *	and /MT says to link with the multi-threaded version
 *	of the C run-time library.  /W4 would work but for
 *	warning 4127 - conditional expression is constant).
 *	If you then run tsample.exe (first) and the sim
 *	(second), this program will read telemetry from the
 *	sim, and write some of it out to its console window.
 *
 *
 */

/*
 * Include files
 */
#include <windows.h>
#include <stdio.h>
#include <math.h>
#include "papytelemapp.h"


/*
 * Miscellaneous definitions local to this file
 */

using namespace PapyTelem;


// If you set this to be true, then the telemetry output will be in
// english units.  Otherwise they are output in SI units.
const bool englishUnits = true;

// When false, sampling is done at the game tick rate (36Hz, currently).
// When true, sampling is done at the physics rate (288Hz, currently).
const bool sampleAtPhysicsRate = false;

const int DRIVER_COUNT = 43;

/*
 * Global/public variables defined
 */


/* ============================================================

*/

static void printCurrentWeekend(CurrentWeekend cw)
{
	//printf(";cw\n");
	printf("currentWeekend{%i;%s;%f;%s;%s}\n",
		cw.atTrack ? 1 : 0, 
		cw.track,
		cw.trackLength,
		cw.sessions,
		cw.options);
	fflush(stdout);
}

static void printDriverEntry(DriverEntry de)
{
	//printf(";de\n");
	printf("driverEntry{%i;%i;%i;%s;%s;%s}\n",
		de.flags,
		de.carIdx,
		de.carMake,
		de.carNum,
		de.name,
		de.carFile);
	fflush(stdout);
}

static void printDriverWithdrawl(DriverWithdrawl dw)
{
	//printf(";dw\n");
	printf("driverWithdrawl{%i}\n",
		dw.carIdx);
	fflush(stdout);
}

static void printSessionInfo(SessionInfo si)
{
	//printf(";si\n");
	printf("sessionInfo{%i;%i;%i;%i;%i;%f;%f;%i}\n",
		si.sessionNum,
		si.sessionCookie,
		si.sessionType,
		si.sessionState,
		si.sessionFlag,
		si.currentTime,
		si.timeRemaining,
		si.lapsRemaining);
	fflush(stdout);
}

static void printLapCrossing (LapCrossing lc)
{
	//printf(";lc\n");
	printf("lapCrossing{%i;%i;%i;%f}\n",
		lc.carIdx,
		lc.lapNum,
		lc.flags,
		lc.crossedAt);
	fflush(stdout);
}

static void printStandingsEntry (StandingsEntry se)
{
	//printf(";se\n");
	printf("standingsEntry{%i;%f;%i;%i;%i;%i}",
		se.carIdx,
		se.time,
		se.lap,
		se.lapsLead,
		se.reasonOut,
		se.incidents);
	fflush(stdout);
}

static void printStandings(Standings s, int numberOfCars)
{
	//printf(";s\n");
	printf("standings{%i;%i;%f;%i;%i;%i;%i;",
		s.flags,
		s.sessionNum,
		s.averageLapTime,
		s.lapsComplete,
		s.numCautionFlags,
		s.numCautionLaps,
		s.numLeadChanges);

	printStandingsEntry(s.fastestLap);

	printf(";");

	for	(int i = 0; i < numberOfCars; i++)
	{
		if (i != 0) printf(";");
		printStandingsEntry(s.position[i]);
	}

	printf("}\n");

	fflush(stdout);
}

static void printMetaWaitingForActive()
{
	//printf(";mwfa\n");
	printf("waitingForActive{}\n");

	fflush(stdout);
}

static void printMetaSimActive()
{
	//printf(";msa\n");
	printf("simActive{}\n");

	fflush(stdout);
}

static void printMetaErrorItem(int index)
{
	//printf(";mei\n");
	printf("errorItem{%i}\n", index);

	fflush(stdout);
}

static void printMetaErrorOverrun()
{
	//printf(";meo\n");
	printf("errorOverrun{}\n");

	fflush(stdout);
}

static void printMetaApplicationExit()
{
	//printf(";mae\n");
	printf("applicationExit{}\n");

	fflush(stdout);
}

static void printDriverInCar (DriverInCar dic) 
{
	//printf(";dic\n");
	printf("driverInCar{%i}\n",
		dic.inCar ? 1 : 0);

	fflush(stdout);
}

static void printGameIsPaused (bool isPaused)
{
	//printf(";gip\n");
	printf ("gamePaused{%i}\n",
		isPaused ? 1 : 0);

	fflush(stdout);
}

static void printGameIsPaused (GameIsPaused gp)
{
	//printf(";gip-2\n");
	printGameIsPaused (gp.paused);

	fflush(stdout);
}









static void  printStateData(
	eSimDataType	newStateData)
{
	switch(newStateData)
	{
		case kCurrentWeekend :
			{
			const CurrentWeekend *wk = (const CurrentWeekend * )
					AppGetSimData(newStateData);
			printCurrentWeekend(*wk);
			break;
			}
		case kDriverInCar :
		{
			const DriverInCar *in = (const DriverInCar * )
					AppGetSimData(newStateData);
			printDriverInCar(*in);
			break;
		}
		case kGameIsPaused :
		{
			const GameIsPaused *paused = (const GameIsPaused * )
					AppGetSimData(newStateData);
			printGameIsPaused(*paused);
			break;
		}
		case kCarSetup :
		{
			printMetaErrorItem(1);		
			AppClearSimData(kPitStop);
			break;
		}

		case kPitStop :
		{
			printMetaErrorItem(2);
			break;
		}

		case kDriverEntry :
		{
			const DriverEntry *entry = (const DriverEntry *)
					AppGetSimData(newStateData);
			printDriverEntry(*entry);
			break;
		}

		case kDriverWithdrawl :
		{
			const DriverWithdrawl *withdrawl = (const DriverWithdrawl *)
					AppGetSimData(newStateData);
			printDriverWithdrawl(*withdrawl);
			break;
		}

		case kSessionInfo :
		{
			const SessionInfo *info = (const SessionInfo *)
					AppGetSimData(newStateData);
			printSessionInfo(*info);
			break;
		}

		case kLapCrossing :
		{
			const LapCrossing *crossing = (const LapCrossing *)
					AppGetSimData(newStateData);
			printLapCrossing(*crossing);
			break;
		}

		case kStandings :
		{
			const Standings *s = (const Standings *)
					AppGetSimData(newStateData);
			printStandings(*s, DRIVER_COUNT);
			break;
		}

		default:
		{
			printMetaErrorItem(5);
			break;
		}
	}
}


/*
 ***************************************************************************
 ***************************************************************************
 */
int main(void)
{
	SetPriorityClass(GetCurrentProcess(), HIGH_PRIORITY_CLASS);

	if (AppBegin("NR2003"))
	{
		const eSimDataType desired[] =
		{
			kCurrentWeekend,		// Want state information, too
			kDriverInCar,
			kGameIsPaused,
			kDriverEntry,
			kDriverWithdrawl,
			kSessionInfo,
			kLapCrossing,
			kStandings
		};

 		(void) AppRequestDataItems(sizeof(desired)/sizeof(desired[0]),
								   desired);
		(void) AppRequestDataAtPhysicsRate(sampleAtPhysicsRate);
		(void) AppEnableSampling(true);

		printMetaWaitingForActive();
		while(!AppCheckIfSimActiveQ())
		{
			Sleep(1000);
		}

		printMetaSimActive();	


		const int timeOutMs = 100;
		eSimDataType newStateData;
		bool newSample;
		while((newSample = AppWaitForNewSample(&newStateData, timeOutMs)) == true ||
			  newStateData != kNoStateInfo ||
			  AppCheckIfSimActiveQ())
		{
			// See if any new telemetry from the sim.
			if (newSample || newStateData != kNoStateInfo)
			{
				// Yes, it has either written a piece of state data,
				// or has finished writing a new sample.  Which one?
				// Either newStateData won't equal kNoStateInfo
				// (meaning a piece of state data was read), or
				// AppWaitForNewSample will return true (indicating
				// a complete sample is now available), but never
				// both at once.
				if (newStateData != kNoStateInfo)
				{
					// It was state data.  Process it.
					printStateData(newStateData);
				}
				else if (newSample)
				{
					printMetaErrorItem(0);

					AppClearSample();
				}

				if (AppCheckIfSimDataOverrunQ())
				{
					printMetaErrorOverrun();

					AppClearSimDataOverrun();
				}
			}
		}

		// Since we successfully called AppBegin, we are obliged to
		// call AppEnd.
		printMetaApplicationExit();
		AppEnd();
	}
	return 0;
}


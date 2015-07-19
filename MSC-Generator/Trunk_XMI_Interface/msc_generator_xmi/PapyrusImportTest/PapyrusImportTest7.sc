DiagramStyle: uml 
DiagramName: Interaction1

PageSize: A4, H
PageMargins: 10,10,10,10 
Font: Arial, 10, Regular 
LineOffset: 20
Author: ''
Company: ''
Date: ''
Version: ''
PrintFootLine: no 

process: FirstLifeline_1, FirstLifeline;
process: SecondLifeline_1, SecondLifeline;
process: ThirdLifeline_1, ThirdLifeline;
process: FourthLifeline_1, FourthLifeline;

regionbegin: FirstLifeline_1, Activation;
	regionbegin: SecondLifeline_1, Activation
		msg: FirstLifeline_1, SecondLifeline_1, FirstMessageSynch,!;

		regionbegin: ThirdLifeline_1, Activation
			msg: SecondLifeline_1, ThirdLifeline_1, SecondMessageSynch,!;
			regionbegin: FourthLifeline_1, Activation
				msg: ThirdLifeline_1, FourthLifeline_1, ThirdMessageSynch,!;
				msg: FourthLifeline_1, ThirdLifeline_1, FourthMessageReply,*
			regionend: FourthLifeline_1;
			msg: ThirdLifeline_1, SecondLifeline_1, FifthMessageReply,*
		regionend: ThirdLifeline_1;
		msg: SecondLifeline_1, FirstLifeline_1, SixthMessageReply,*
	regionend: SecondLifeline_1;
	regionbegin: FourthLifeline_1, Activation
		msg: FirstLifeline_1, FourthLifeline_1, SeventhMessageSynch,!;
	regionend: FourthLifeline_1;
	regionbegin: SecondLifeline_1, Activation
		msg: FirstLifeline_1, SecondLifeline_1, EightMessageSynch,!;
		regionend: SecondLifeline_1;
	regionend: FirstLifeline_1;
regionbegin: ThirdLifeline_1, Activation;
	regionbegin: FirstLifeline_1, Activation
		msg: ThirdLifeline_1, FirstLifeline_1, NinthMessageAsynch;
	regionend: FirstLifeline_1;
	regionbegin: FirstLifeline_1, Activation
		msg: ThirdLifeline_1, FirstLifeline_1, TenthMessageAsync;
	regionend: FirstLifeline_1;
regionend: ThirdLifeline_1;
regionbegin: SecondLifeline_1, Activation;
	regionbegin: FourthLifeline_1, Activation
		msg: SecondLifeline_1, FourthLifeline_1, EleventhMessage;
	regionend: FourthLifeline_1;
regionend: SecondLifeline_1;

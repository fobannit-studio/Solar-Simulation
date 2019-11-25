﻿/*
© Siemens AG, 2019
Author: Berkay Alp Cakal (berkay_alp.cakal.ct@siemens.com)

Licensed under the Apache License, Version 2.0 (the "License");
you may not use this file except in compliance with the License.
You may obtain a copy of the License at
<http://www.apache.org/licenses/LICENSE-2.0>.
Unless required by applicable law or agreed to in writing, software
distributed under the License is distributed on an "AS IS" BASIS,
WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
See the License for the specific language governing permissions and
limitations under the License.
*/

using System;
using UnityEngine;
using RosSharp.RosBridgeClient.Actionlib;
using RosSharp.RosBridgeClient.MessageTypes.ActionlibTutorials;

namespace RosSharp.RosBridgeClient
{
    public class FibonacciActionClient : UnityActionClient<FibonacciAction, FibonacciActionGoal, FibonacciActionResult, FibonacciActionFeedback, FibonacciGoal, FibonacciResult, FibonacciFeedback>
    {       
        public  int fibonacciOrder = 20;
        public string status = "";
        public string feedback = "";
        public string result = "";
      
        protected override void Start()
        {
            base.Start();
            action = new FibonacciAction();
            action.action_goal.goal.order = fibonacciOrder;
        }

        private void Update()
        {
            status   = GetStatusString();
            feedback = GetFeedbackString();
            result   = GetResultString();
        }

        protected override FibonacciActionGoal GetActionGoal()
        {
            action.action_goal.goal.order = fibonacciOrder;
            return action.action_goal;
        }

        protected override void OnFeedbackReceived()
        {
            // Not implemented since get string directly returns stored feedback
        }

        protected override void OnResultReceived()
        {
            // Not implemented since get string directly returns stored result
        }

        public string GetStatusString()
        {
            if (goalStatus != null) {
                return ((ActionStatus)(goalStatus.status)).ToString();
            }
            return "";
        }

        public string GetFeedbackString()
        {
            if (action != null)
                return String.Join(",", action.action_feedback.feedback.sequence);
            return "";
        }

        public string GetResultString()
        {
            if (action != null)
                return String.Join(",", action.action_result.result.sequence);
            return "";
        }
    }
}
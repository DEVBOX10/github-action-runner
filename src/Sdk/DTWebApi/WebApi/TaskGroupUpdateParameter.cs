﻿using System;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace GitHub.DistributedTask.WebApi
{
    [DataContract]
    public class TaskGroupUpdateParameter
    {
        /// <summary>
        /// Sets the unique identifier of this field.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Guid Id { get; set; }

        /// <summary>
        /// Sets name of the task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public String Name { get; set; }

        /// <summary>
        /// Sets friendly name of the task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public String FriendlyName { get; set; }

        /// <summary>
        /// Sets author name of the task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public String Author { get; set; }

        /// <summary>
        /// Sets description of the task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public String Description { get; set; }

        /// <summary>
        /// Sets comment of the task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public String Comment { get; set; }

        /// <summary>
        /// Sets revision of the task group.
        /// </summary>
        [DataMember]
        public Int32 Revision { get; set; }

        /// <summary>
        /// Gets or sets parent task group Id. This is used while creating a draft task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public Guid? ParentDefinitionId { get; set; }

        /// <summary>
        /// Sets url icon of the task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public String IconUrl { get; set; }

        /// <summary>
        /// Sets display name of the task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public String InstanceNameFormat { get; set; }

        /// <summary>
        /// Sets category of the task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public String Category { get; set; }

        /// <summary>
        /// Sets version of the task group.
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public TaskVersion Version { get; set; }

        public IList<TaskGroupStep> Tasks
        {
            get
            {
                if (m_tasks == null)
                {
                    m_tasks = new List<TaskGroupStep>();
                }

                return m_tasks;
            }
        }

        public IList<TaskInputDefinition> Inputs
        {
            get
            {
                if (m_inputs == null)
                {
                    m_inputs = new List<TaskInputDefinition>();
                }
                return m_inputs;
            }
        }

        public IList<String> RunsOn
        {
            get
            {
                if (m_runsOn == null)
                {
                    m_runsOn = new List<String>(TaskRunsOnConstants.DefaultValue);
                }

                return m_runsOn;
            }
        }

        [OnDeserialized]
        private void OnDeserialized(StreamingContext context)
        {
            SerializationHelper.Copy(ref m_serializedRunsOn, ref m_runsOn, true);
        }

        [OnSerializing]
        private void OnSerializing(StreamingContext context)
        {
            SerializationHelper.Copy(ref m_runsOn, ref m_serializedRunsOn);
        }

        [OnSerialized]
        private void OnSerialized(StreamingContext context)
        {
            m_serializedRunsOn = null;
        }

        /// <summary>
        /// Sets tasks for the task group.
        /// </summary>
        [DataMember(Name = "Tasks")]
        private IList<TaskGroupStep> m_tasks;

        /// <summary>
        /// Sets input for the task group.
        /// </summary>
        [DataMember(Name = "Inputs", EmitDefaultValue = false)]
        private List<TaskInputDefinition> m_inputs;

        /// <summary>
        /// Sets RunsOn of the task group. Value can be 'Agent', 'Server' or 'DeploymentGroup'.
        /// </summary>
        [DataMember(Name = "RunsOn", EmitDefaultValue = false)]
        private List<String> m_serializedRunsOn;

        private List<String> m_runsOn;
    }
}
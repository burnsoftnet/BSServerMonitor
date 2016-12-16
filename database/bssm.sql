/*
SQLyog Enterprise - MySQL GUI v5.20
Host - 5.0.37-community-nt : Database - bssm
*********************************************************************
Server version : 5.0.37-community-nt
*/

SET NAMES utf8;

SET SQL_MODE='';

create database if not exists `bssm`;

USE `bssm`;

SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO';

/*Table structure for table `application_actions_port` */

DROP TABLE IF EXISTS `application_actions_port`;

CREATE TABLE `application_actions_port` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `AID` int(10) unsigned NOT NULL COMMENT 'Application ID',
  `PID` varchar(45) NOT NULL COMMENT 'Port ID',
  `Actions` text NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `application_name` */

DROP TABLE IF EXISTS `application_name`;

CREATE TABLE `application_name` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `appname` varchar(255) NOT NULL,
  `appdesc` text NOT NULL,
  `Port` bigint(20) default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `events_general` */

DROP TABLE IF EXISTS `events_general`;

CREATE TABLE `events_general` (
  `ID` int(10) NOT NULL auto_increment,
  `SID` int(10) default NULL,
  `DT` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `shrtEv` varchar(255) default NULL,
  `lngEv` text,
  `Sev` varchar(10) default '1',
  `IsNew` varchar(10) default '1',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=163 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `events_general_archive` */

DROP TABLE IF EXISTS `events_general_archive`;

CREATE TABLE `events_general_archive` (
  `ID` int(10) NOT NULL default '0',
  `SID` int(10) default NULL,
  `DT` timestamp NOT NULL default '0000-00-00 00:00:00',
  `shrtEv` varchar(255) default NULL,
  `lngEv` text,
  `Sev` varchar(10) default '1',
  `IsNew` varchar(10) default '1'
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `list_collectors` */

DROP TABLE IF EXISTS `list_collectors`;

CREATE TABLE `list_collectors` (
  `ID` int(4) NOT NULL auto_increment,
  `ServerName` varchar(255) default NULL,
  `IsEnabled` int(4) default '1',
  `LUD` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  PRIMARY KEY  (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=3 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `list_collectors_tempass` */

DROP TABLE IF EXISTS `list_collectors_tempass`;

CREATE TABLE `list_collectors_tempass` (
  `CID` int(11) default NULL,
  `SID` int(11) default NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC COMMENT='InnoDB free: 4096 kB';

/*Table structure for table `list_servers` */

DROP TABLE IF EXISTS `list_servers`;

CREATE TABLE `list_servers` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` int(10) unsigned NOT NULL default '1' COMMENT 'Current Status',
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` int(10) unsigned NOT NULL default '1',
  `DTAdded` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `CID` int(10) default '0' COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default '1',
  `DoTrace` int(10) default '0',
  `DoPort` int(10) default '0',
  `DoHTTP` int(10) default '0',
  `PingRepeats` int(10) default '10',
  `TID` int(10) unsigned NOT NULL default '1',
  `IsReported` int(10) unsigned NOT NULL default '0',
  `IIPAC` int(10) default '0',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=428 DEFAULT CHARSET=latin1;

/*Table structure for table `list_servers_ports` */

DROP TABLE IF EXISTS `list_servers_ports`;

CREATE TABLE `list_servers_ports` (
  `ID` int(10) NOT NULL auto_increment,
  `SID` int(10) default '0' COMMENT 'Machine ID',
  `Port` int(10) default '0' COMMENT 'Port Number',
  `protocol` varchar(255) default 'tcp' COMMENT 'tcp/udp',
  `r_app_name` varchar(255) default 'N/A',
  `IsEnabled` int(4) default '0' COMMENT 'Monitoring Enabled',
  `CS` int(4) default '1' COMMENT 'Current Status',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=287 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `list_servers_types` */

DROP TABLE IF EXISTS `list_servers_types`;

CREATE TABLE `list_servers_types` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `Cat` varchar(255) NOT NULL,
  `Desc` text NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Table structure for table `port_listings` */

DROP TABLE IF EXISTS `port_listings`;

CREATE TABLE `port_listings` (
  `ID` int(11) NOT NULL auto_increment,
  `port` int(11) default NULL,
  `protocol` varchar(50) default 'tcp',
  `AppName_C` varchar(255) default '?',
  `AppName_R` varchar(255) default 'UNKNOWN',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=7 DEFAULT CHARSET=latin1;

/*Table structure for table `port_monitoring_details` */

DROP TABLE IF EXISTS `port_monitoring_details`;

CREATE TABLE `port_monitoring_details` (
  `ID` int(11) NOT NULL,
  `PID` int(11) default NULL COMMENT 'Port ID from Port_listing',
  `AppDesc` text COMMENT 'Description of the application',
  `def_alert_msg` text COMMENT 'Default alert message for the events',
  `std_monitor` int(10) default '0' COMMENT 'Make This a Default for all devices.',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `results_ping_raw` */

DROP TABLE IF EXISTS `results_ping_raw`;

CREATE TABLE `results_ping_raw` (
  `ID` int(10) unsigned zerofill NOT NULL auto_increment,
  `TSID` int(10) unsigned NOT NULL default '0',
  `SIP` varchar(255) NOT NULL,
  `MyBytes` int(10) unsigned NOT NULL,
  `MyTime` int(10) unsigned NOT NULL,
  `MyTTL` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=180481 DEFAULT CHARSET=latin1;

/*Table structure for table `results_ping_stats` */

DROP TABLE IF EXISTS `results_ping_stats`;

CREATE TABLE `results_ping_stats` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `TSID` int(10) unsigned NOT NULL default '0',
  `Packets_Sent` int(10) unsigned NOT NULL,
  `Packets_Rec` int(10) unsigned NOT NULL,
  `Packets_Lost` int(10) unsigned NOT NULL,
  `RoundTrip_Min` int(10) unsigned NOT NULL,
  `RoundTrip_Max` int(10) unsigned NOT NULL,
  `RoundTrip_Avg` int(10) unsigned NOT NULL,
  `uptime` double NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=17574 DEFAULT CHARSET=latin1;

/*Table structure for table `results_port_test` */

DROP TABLE IF EXISTS `results_port_test`;

CREATE TABLE `results_port_test` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `PID` int(10) unsigned NOT NULL,
  `iSent` int(10) unsigned NOT NULL,
  `iRec` int(10) unsigned NOT NULL,
  `uptime` double NOT NULL,
  `DTT` timestamp NOT NULL default CURRENT_TIMESTAMP on update CURRENT_TIMESTAMP,
  `CS` int(10) unsigned NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `results_timestamp` */

DROP TABLE IF EXISTS `results_timestamp`;

CREATE TABLE `results_timestamp` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `SID` int(10) unsigned NOT NULL,
  `DTID` timestamp NOT NULL default CURRENT_TIMESTAMP,
  `ls` int(10) unsigned NOT NULL default '1',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=18657 DEFAULT CHARSET=latin1;

/*Table structure for table `results_trace` */

DROP TABLE IF EXISTS `results_trace`;

CREATE TABLE `results_trace` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `SID` int(10) unsigned NOT NULL,
  `hopno` int(10) NOT NULL,
  `ttl` int(10) default NULL,
  `rtt` int(10) default NULL,
  `ipaddr` varchar(255) default NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=13 DEFAULT CHARSET=latin1;

/*Table structure for table `self_lastrun` */

DROP TABLE IF EXISTS `self_lastrun`;

CREATE TABLE `self_lastrun` (
  `LastRun` datetime default NULL
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_daily` */

DROP TABLE IF EXISTS `uptime_stats_daily`;

CREATE TABLE `uptime_stats_daily` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `DT` datetime NOT NULL,
  `SID` int(11) default NULL,
  `uptime` double NOT NULL default '100',
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM AUTO_INCREMENT=22 DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_monthly` */

DROP TABLE IF EXISTS `uptime_stats_monthly`;

CREATE TABLE `uptime_stats_monthly` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `dt` datetime NOT NULL,
  `SID` int(11) default NULL,
  `uptime` double NOT NULL default '100',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_monthly_general` */

DROP TABLE IF EXISTS `uptime_stats_monthly_general`;

CREATE TABLE `uptime_stats_monthly_general` (
  `id` int(11) NOT NULL auto_increment,
  `dt_m` int(11) default NULL,
  `dt_y` int(11) default NULL,
  `t_uptime` double default '0',
  `dtins` timestamp NULL default CURRENT_TIMESTAMP,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_weekly` */

DROP TABLE IF EXISTS `uptime_stats_weekly`;

CREATE TABLE `uptime_stats_weekly` (
  `id` int(10) unsigned NOT NULL auto_increment,
  `dt_start` datetime NOT NULL,
  `dt_end` datetime NOT NULL,
  `SID` int(11) default NULL,
  `uptime` double NOT NULL default '100',
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_yearly` */

DROP TABLE IF EXISTS `uptime_stats_yearly`;

CREATE TABLE `uptime_stats_yearly` (
  `ID` int(10) unsigned NOT NULL auto_increment,
  `myyear` int(10) unsigned default NULL,
  `SID` int(11) default NULL,
  `uptime` double NOT NULL,
  PRIMARY KEY  (`ID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

/*Table structure for table `view_collector_list` */

DROP TABLE IF EXISTS `view_collector_list`;

DROP VIEW IF EXISTS `view_collector_list`;

CREATE TABLE `view_collector_list` (
  `ID` int(4) NOT NULL default '0',
  `ServerName` varchar(255) default NULL,
  `Status` varchar(8) default NULL,
  `LUD` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CL` bigint(21) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `view_monthly_gen_friendlydates` */

DROP TABLE IF EXISTS `view_monthly_gen_friendlydates`;

DROP VIEW IF EXISTS `view_monthly_gen_friendlydates`;

CREATE TABLE `view_monthly_gen_friendlydates` (
  `id` int(11) NOT NULL default '0',
  `dt_y` int(11) default NULL,
  `dt_m` int(11) default NULL,
  `t_uptime` double default NULL,
  `dt` varchar(69) character set utf8 default NULL,
  `dtins` timestamp NULL default NULL,
  `t_downtime` varbinary(23) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `view_ping_timepingstats` */

DROP TABLE IF EXISTS `view_ping_timepingstats`;

DROP VIEW IF EXISTS `view_ping_timepingstats`;

CREATE TABLE `view_ping_timepingstats` (
  `ID` int(10) unsigned NOT NULL default '0',
  `SID` int(10) unsigned NOT NULL,
  `DTID` timestamp NOT NULL default '0000-00-00 00:00:00',
  `ls` int(10) unsigned NOT NULL default '0',
  `Packets_Sent` int(10) unsigned NOT NULL,
  `Packets_Rec` int(10) unsigned NOT NULL,
  `Packets_Lost` int(10) unsigned NOT NULL,
  `RoundTrip_Min` int(10) unsigned NOT NULL,
  `RoundTrip_Max` int(10) unsigned NOT NULL,
  `RoundTrip_Avg` int(10) unsigned NOT NULL,
  `uptime` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_all` */

DROP TABLE IF EXISTS `view_servers_all`;

DROP VIEW IF EXISTS `view_servers_all`;

CREATE TABLE `view_servers_all` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` varchar(10) default NULL,
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` varchar(8) default NULL,
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `DoPing` varchar(3) default NULL,
  `DoTrace` varchar(3) default NULL,
  `DoPort` varchar(3) default NULL,
  `DoHTTP` varchar(3) default NULL,
  `Cat` varchar(255) NOT NULL,
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_disabled` */

DROP TABLE IF EXISTS `view_servers_disabled`;

DROP VIEW IF EXISTS `view_servers_disabled`;

CREATE TABLE `view_servers_disabled` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` int(10) unsigned NOT NULL default '0' COMMENT 'Current Status',
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` int(10) unsigned NOT NULL default '0',
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default NULL,
  `DoTrace` int(10) default NULL,
  `DoPort` int(10) default NULL,
  `DoHTTP` int(10) default NULL,
  `Cat` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_downonly` */

DROP TABLE IF EXISTS `view_servers_downonly`;

DROP VIEW IF EXISTS `view_servers_downonly`;

CREATE TABLE `view_servers_downonly` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` int(10) unsigned NOT NULL default '0' COMMENT 'Current Status',
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` int(10) unsigned NOT NULL default '0',
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default NULL,
  `DoTrace` int(10) default NULL,
  `DoPort` int(10) default NULL,
  `DoHTTP` int(10) default NULL,
  `Cat` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_errorsonly` */

DROP TABLE IF EXISTS `view_servers_errorsonly`;

DROP VIEW IF EXISTS `view_servers_errorsonly`;

CREATE TABLE `view_servers_errorsonly` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` varchar(10) default NULL,
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` varchar(8) default NULL,
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default NULL,
  `DoTrace` int(10) default NULL,
  `DoPort` int(10) default NULL,
  `DoHTTP` int(10) default NULL,
  `Cat` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_uponly` */

DROP TABLE IF EXISTS `view_servers_uponly`;

DROP VIEW IF EXISTS `view_servers_uponly`;

CREATE TABLE `view_servers_uponly` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` int(10) unsigned NOT NULL default '0' COMMENT 'Current Status',
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` int(10) unsigned NOT NULL default '0',
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default NULL,
  `DoTrace` int(10) default NULL,
  `DoPort` int(10) default NULL,
  `DoHTTP` int(10) default NULL,
  `Cat` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_all` */

DROP TABLE IF EXISTS `web_view_servers_all`;

DROP VIEW IF EXISTS `web_view_servers_all`;

CREATE TABLE `web_view_servers_all` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` varchar(30) default NULL,
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` int(10) unsigned NOT NULL default '0',
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default NULL,
  `DoTrace` int(10) default NULL,
  `DoPort` int(10) default NULL,
  `DoHTTP` int(10) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_disabled` */

DROP TABLE IF EXISTS `web_view_servers_disabled`;

DROP VIEW IF EXISTS `web_view_servers_disabled`;

CREATE TABLE `web_view_servers_disabled` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` varchar(30) default NULL,
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` int(10) unsigned NOT NULL default '0',
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default NULL,
  `DoTrace` int(10) default NULL,
  `DoPort` int(10) default NULL,
  `DoHTTP` int(10) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_downonly` */

DROP TABLE IF EXISTS `web_view_servers_downonly`;

DROP VIEW IF EXISTS `web_view_servers_downonly`;

CREATE TABLE `web_view_servers_downonly` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` varchar(30) default NULL,
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` int(10) unsigned NOT NULL default '0',
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default NULL,
  `DoTrace` int(10) default NULL,
  `DoPort` int(10) default NULL,
  `DoHTTP` int(10) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_errorsonly` */

DROP TABLE IF EXISTS `web_view_servers_errorsonly`;

DROP VIEW IF EXISTS `web_view_servers_errorsonly`;

CREATE TABLE `web_view_servers_errorsonly` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` varchar(30) default NULL,
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` int(10) unsigned NOT NULL default '0',
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default NULL,
  `DoTrace` int(10) default NULL,
  `DoPort` int(10) default NULL,
  `DoHTTP` int(10) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_uponly` */

DROP TABLE IF EXISTS `web_view_servers_uponly`;

DROP VIEW IF EXISTS `web_view_servers_uponly`;

CREATE TABLE `web_view_servers_uponly` (
  `ID` int(10) unsigned NOT NULL default '0',
  `ServerName` varchar(45) NOT NULL,
  `ServerIPAddress` varchar(255) NOT NULL,
  `CS` varchar(30) default NULL,
  `DisplayName` varchar(45) NOT NULL,
  `IsEnabled` int(10) unsigned NOT NULL default '0',
  `DTAdded` timestamp NOT NULL default '0000-00-00 00:00:00',
  `CID` int(10) default NULL COMMENT 'Collector ID, 0=All',
  `DoPing` int(10) default NULL,
  `DoTrace` int(10) default NULL,
  `DoPort` int(10) default NULL,
  `DoHTTP` int(10) default NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*View structure for view view_collector_list */

DROP VIEW IF EXISTS `view_collector_list`;

DROP TABLE IF EXISTS `view_collector_list`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_collector_list` AS (select `list_collectors`.`ID` AS `ID`,`list_collectors`.`ServerName` AS `ServerName`,(case `list_collectors`.`IsEnabled` when 0 then _latin1'Disabled' when 1 then _latin1'Enabled' end) AS `Status`,`list_collectors`.`LUD` AS `LUD`,(select count(0) AS `Count(*)` from `list_servers` `ls` where (`ls`.`CID` = `list_collectors`.`ID`)) AS `CL` from `list_collectors`);

/*View structure for view view_monthly_gen_friendlydates */

DROP VIEW IF EXISTS `view_monthly_gen_friendlydates`;

DROP TABLE IF EXISTS `view_monthly_gen_friendlydates`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_monthly_gen_friendlydates` AS (select `uptime_stats_monthly_general`.`id` AS `id`,`uptime_stats_monthly_general`.`dt_y` AS `dt_y`,`uptime_stats_monthly_general`.`dt_m` AS `dt_m`,`uptime_stats_monthly_general`.`t_uptime` AS `t_uptime`,date_format(concat(`uptime_stats_monthly_general`.`dt_y`,_latin1'-',`uptime_stats_monthly_general`.`dt_m`,_latin1'-01'),_latin1'%M %Y') AS `dt`,`uptime_stats_monthly_general`.`dtins` AS `dtins`,concat((100 - `uptime_stats_monthly_general`.`t_uptime`)) AS `t_downtime` from `uptime_stats_monthly_general` order by `uptime_stats_monthly_general`.`dt_y` desc);

/*View structure for view view_ping_timepingstats */

DROP VIEW IF EXISTS `view_ping_timepingstats`;

DROP TABLE IF EXISTS `view_ping_timepingstats`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_ping_timepingstats` AS (select `results_timestamp`.`ID` AS `ID`,`results_timestamp`.`SID` AS `SID`,`results_timestamp`.`DTID` AS `DTID`,`results_timestamp`.`ls` AS `ls`,`results_ping_stats`.`Packets_Sent` AS `Packets_Sent`,`results_ping_stats`.`Packets_Rec` AS `Packets_Rec`,`results_ping_stats`.`Packets_Lost` AS `Packets_Lost`,`results_ping_stats`.`RoundTrip_Min` AS `RoundTrip_Min`,`results_ping_stats`.`RoundTrip_Max` AS `RoundTrip_Max`,`results_ping_stats`.`RoundTrip_Avg` AS `RoundTrip_Avg`,`results_ping_stats`.`uptime` AS `uptime` from (`results_timestamp` join `results_ping_stats` on((`results_timestamp`.`ID` = `results_ping_stats`.`TSID`))) order by `results_timestamp`.`DTID` desc);

/*View structure for view view_servers_all */

DROP VIEW IF EXISTS `view_servers_all`;

DROP TABLE IF EXISTS `view_servers_all`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_servers_all` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then _latin1'Down' when 1 then _latin1'Up' when 2 then _latin1'IP Changed' when 3 then _latin1'Disabled' when 4 then _latin1'Slow' when 5 then _latin1'Down' end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,(case `list_servers`.`IsEnabled` when 0 then _latin1'Disabled' when 1 then _latin1'Enabled' end) AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,(case `list_servers`.`DoPing` when 0 then _latin1'No' when 1 then _latin1'Yes' end) AS `DoPing`,(case `list_servers`.`DoTrace` when 0 then _latin1'No' when 1 then _latin1'Yes' end) AS `DoTrace`,(case `list_servers`.`DoPort` when 0 then _latin1'No' when 1 then _latin1'Yes' end) AS `DoPort`,(case `list_servers`.`DoHTTP` when 0 then _latin1'No' when 1 then _latin1'Yes' end) AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat`,`list_servers`.`CID` AS `CID` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))));

/*View structure for view view_servers_disabled */

DROP VIEW IF EXISTS `view_servers_disabled`;

DROP TABLE IF EXISTS `view_servers_disabled`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_servers_disabled` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,`list_servers`.`CS` AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))) where ((`list_servers`.`IsEnabled` = 0) and (`list_servers`.`CS` <> 5)) order by `list_servers`.`ServerName`);

/*View structure for view view_servers_downonly */

DROP VIEW IF EXISTS `view_servers_downonly`;

DROP TABLE IF EXISTS `view_servers_downonly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_servers_downonly` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,`list_servers`.`CS` AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))) where ((`list_servers`.`CS` = 0) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view view_servers_errorsonly */

DROP VIEW IF EXISTS `view_servers_errorsonly`;

DROP TABLE IF EXISTS `view_servers_errorsonly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_servers_errorsonly` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then _latin1'Down' when 1 then _latin1'Up' when 2 then _latin1'IP Changed' when 3 then _latin1'Disabled' when 4 then _latin1'Slow' when 5 then _latin1'Deleted' end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,(case `list_servers`.`IsEnabled` when 0 then _latin1'Disabled' when 1 then _latin1'Enabled' end) AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))) where ((`list_servers`.`CS` <> 1) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view view_servers_uponly */

DROP VIEW IF EXISTS `view_servers_uponly`;

DROP TABLE IF EXISTS `view_servers_uponly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `view_servers_uponly` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,`list_servers`.`CS` AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))) where ((`list_servers`.`CS` = 1) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view web_view_servers_all */

DROP VIEW IF EXISTS `web_view_servers_all`;

DROP TABLE IF EXISTS `web_view_servers_all`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `web_view_servers_all` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif"') when 1 then concat(_latin1'<img src="images/up.gif"') when 2 then concat(_latin1'<img src="images/warn.gif"') when 3 then concat(_latin1'<img src="images/disabled.gif"') when 4 then concat(_latin1'<img src="images/warn.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP` from `list_servers` order by `list_servers`.`ServerName`);

/*View structure for view web_view_servers_disabled */

DROP VIEW IF EXISTS `web_view_servers_disabled`;

DROP TABLE IF EXISTS `web_view_servers_disabled`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `web_view_servers_disabled` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif"') when 1 then concat(_latin1'<img src="images/up.gif"') when 2 then concat(_latin1'<img src="images/warn.gif"') when 3 then concat(_latin1'<img src="images/disabled.gif"') when 4 then concat(_latin1'<img src="images/warn.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP` from `list_servers` where (`list_servers`.`IsEnabled` = 0) order by `list_servers`.`ServerName`);

/*View structure for view web_view_servers_downonly */

DROP VIEW IF EXISTS `web_view_servers_downonly`;

DROP TABLE IF EXISTS `web_view_servers_downonly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `web_view_servers_downonly` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif"') when 1 then concat(_latin1'<img src="images/up.gif"') when 2 then concat(_latin1'<img src="images/warn.gif"') when 3 then concat(_latin1'<img src="images/disabled.gif"') when 4 then concat(_latin1'<img src="images/warn.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP` from `list_servers` where ((`list_servers`.`CS` = 0) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view web_view_servers_errorsonly */

DROP VIEW IF EXISTS `web_view_servers_errorsonly`;

DROP TABLE IF EXISTS `web_view_servers_errorsonly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `web_view_servers_errorsonly` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif"') when 1 then concat(_latin1'<img src="images/up.gif"') when 2 then concat(_latin1'<img src="images/warn.gif"') when 3 then concat(_latin1'<img src="images/disabled.gif"') when 4 then concat(_latin1'<img src="images/warn.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP` from `list_servers` where ((`list_servers`.`CS` <> 1) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view web_view_servers_uponly */

DROP VIEW IF EXISTS `web_view_servers_uponly`;

DROP TABLE IF EXISTS `web_view_servers_uponly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`root`@`localhost` SQL SECURITY DEFINER VIEW `web_view_servers_uponly` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif"') when 1 then concat(_latin1'<img src="images/up.gif"') when 2 then concat(_latin1'<img src="images/warn.gif"') when 3 then concat(_latin1'<img src="images/disabled.gif"') when 4 then concat(_latin1'<img src="images/warn.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP` from `list_servers` where ((`list_servers`.`CS` = 1) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/* Procedure structure for procedure `sp_mnt_pingdata` */

drop procedure if exists `sp_mnt_pingdata`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_mnt_pingdata`(iday int)
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare ReqID int;
	DECLARE RID CURSOR FOR select ID from view_ping_timepingstats where DTID < adddate(CURRENT_TIMESTAMP, INTERVAL -iDay DAY);
	DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
	Open RID;
	REPEAT
		FETCH RID INTO ReqID;
		delete from results_ping_raw where TSID=ReqID;
		delete from results_ping_stats where TSID=ReqID;
		delete from results_timestamp where ID=ReqID;
	UNTIL done END REPEAT;
	Close RID;
    END$$

DELIMITER ;

/* Procedure structure for procedure `sp_mnt_rawpingdata_day` */

drop procedure if exists `sp_mnt_rawpingdata_day`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_mnt_rawpingdata_day`(iday int)
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare ReqID int;
	DECLARE RID CURSOR FOR select ID from view_ping_timepingstats where DTID < adddate(CURRENT_TIMESTAMP, INTERVAL -iDay DAY);
	DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
	Open RID;
	REPEAT
		FETCH RID INTO ReqID;
		delete from results_ping_raw where TSID=ReqID;
	UNTIL done END REPEAT;
	Close RID;
    END$$

DELIMITER ;

/* Procedure structure for procedure `sp_mnt_rawpingdata_hrs` */

drop procedure if exists `sp_mnt_rawpingdata_hrs`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_mnt_rawpingdata_hrs`(ihrs int)
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare ReqID int;
	DECLARE RID CURSOR FOR select ID from view_ping_timepingstats where DTID < adddate(CURRENT_TIMESTAMP, INTERVAL -ihrs HOUR);
	DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
	Open RID;
	REPEAT
		FETCH RID INTO ReqID;
		delete from results_ping_raw where TSID=ReqID;
	UNTIL done END REPEAT;
	Close RID;
    END$$

DELIMITER ;

/* Procedure structure for procedure `sp_server_delete` */

drop procedure if exists `sp_server_delete`;

DELIMITER $$

CREATE DEFINER=`root`@`localhost` PROCEDURE `sp_server_delete`(MSID int)
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare ResID int;
	DECLARE PINGSTATS CURSOR FOR select ID from results_timestamp where SID=MSID;
	DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
	delete from list_servers_ports where SID=MSID;
	delete from events_general where SID=MSID;
	Open PINGSTATS;
	REPEAT
		FETCH PINGSTATS INTO ResID;
		Delete from results_ping_raw where TSID=ResID;
		Delete from results_ping_stats where TSID=ResID;
	UNTIL done END REPEAT;
	Close PINGSTATS;
    END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;

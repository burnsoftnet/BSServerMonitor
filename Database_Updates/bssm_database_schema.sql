/*
SQLyog Enterprise - MySQL GUI v5.20
Host - 5.1.30-community : Database - bssm
*********************************************************************
Server version : 5.1.30-community
*/


SET NAMES utf8;

SET SQL_MODE='';

CREATE DATABASE IF NOT EXISTS `bssm`;

GRANT USAGE ON *.* TO 'bssm'@'%';
DROP USER 'bssm'@'%';
CREATE USER 'bssm'@'%';
SET PASSWORD FOR 'bssm'@'%' = PASSWORD('bs.server.mon');
GRANT ALL PRIVILEGES ON *.* TO 'bssm'@'%';
GRANT ALL PRIVILEGES ON bssm.* TO 'bssm'@'%';
FLUSH PRIVILEGES;


USE `bssm`;

SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO';

/*Table Structure for Database Version */
DROP TABLE IF EXISTS `DB_Version`;

CREATE TABLE `DB_Version` (
  `ID` INT NOT NULL AUTO_INCREMENT,
  `verNo` VARCHAR(45) NULL,
  `dtUpdated` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`),
  UNIQUE INDEX `ID_UNIQUE` (`ID` ASC));

INSERT INTO `DB_Version` (verNo) VALUES(1.5);

/*Table structure for table `application_actions_port` */

DROP TABLE IF EXISTS `application_actions_port`;

CREATE TABLE `application_actions_port` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `AID` INT(10) UNSIGNED NOT NULL COMMENT 'Application ID',
  `PID` VARCHAR(45) NOT NULL COMMENT 'Port ID',
  `Actions` TEXT NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM DEFAULT CHARSET=latin1;

/*Table structure for table `application_name` */

DROP TABLE IF EXISTS `application_name`;

CREATE TABLE `application_name` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `appname` VARCHAR(255) NOT NULL,
  `appdesc` TEXT NOT NULL,
  `Port` BIGINT(20) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM DEFAULT CHARSET=latin1;

/*Table structure for table `events_general` */

DROP TABLE IF EXISTS `events_general`;

CREATE TABLE `events_general` (
  `ID` INT(10) NOT NULL AUTO_INCREMENT,
  `SID` INT(10) DEFAULT NULL,
  `DT` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `shrtEv` VARCHAR(255) DEFAULT NULL,
  `lngEv` TEXT,
  `Sev` VARCHAR(10) DEFAULT '1',
  `IsNew` VARCHAR(10) DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=381082 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `events_website` */

DROP TABLE IF EXISTS `events_website`;

CREATE TABLE `events_website` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SID` INT(11) DEFAULT NULL COMMENT '	',
  `WID` INT(11) DEFAULT NULL,
  `DT` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `shrtEV` VARCHAR(255) DEFAULT NULL,
  `lngEv` TEXT,
  `Sev` VARCHAR(255) DEFAULT NULL,
  `IsNew` INT(11) DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=INNODB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `list_collectors` */

DROP TABLE IF EXISTS `list_collectors`;

CREATE TABLE `list_collectors` (
  `ID` INT(4) NOT NULL AUTO_INCREMENT,
  `ServerName` VARCHAR(255) DEFAULT NULL,
  `IsEnabled` INT(4) DEFAULT '1',
  `LUD` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `IsBalanced` INT(4) DEFAULT '1',
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=12 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `list_collectors_tempass` */

DROP TABLE IF EXISTS `list_collectors_tempass`;

CREATE TABLE `list_collectors_tempass` (
  `CID` INT(11) DEFAULT NULL,
  `SID` INT(11) DEFAULT NULL
) ENGINE=MYISAM DEFAULT CHARSET=latin1;

/*Table structure for table `list_servers` */

DROP TABLE IF EXISTS `list_servers`;

CREATE TABLE `list_servers` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `ServerName` VARCHAR(45) NOT NULL,
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` INT(10) UNSIGNED NOT NULL DEFAULT '1' COMMENT 'Current Status',
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '1',
  `DTAdded` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `CID` INT(10) DEFAULT '0' COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT '1',
  `DoTrace` INT(10) DEFAULT '1',
  `DoPort` INT(10) DEFAULT '1',
  `DoHTTP` INT(10) DEFAULT '0',
  `PingRepeats` INT(10) DEFAULT '10',
  `TID` INT(10) UNSIGNED NOT NULL DEFAULT '1',
  `IsReported` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `IIPAC` INT(10) DEFAULT '0',
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=2688 DEFAULT CHARSET=latin1;

/*Table structure for table `list_servers_ports` */

DROP TABLE IF EXISTS `list_servers_ports`;

CREATE TABLE `list_servers_ports` (
  `ID` INT(10) NOT NULL AUTO_INCREMENT,
  `SID` INT(10) DEFAULT '0' COMMENT 'Machine ID',
  `Port` INT(10) DEFAULT '0' COMMENT 'Port Number',
  `protocol` VARCHAR(255) DEFAULT 'tcp' COMMENT 'tcp/udp',
  `IsEnabled` INT(4) DEFAULT '0' COMMENT 'Monitoring Enabled',
  `CS` INT(4) DEFAULT '1' COMMENT 'Current Status',
  `r_app_name` VARCHAR(255) NOT NULL DEFAULT 'N/A',
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=61179 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `list_servers_types` */

DROP TABLE IF EXISTS `list_servers_types`;

CREATE TABLE `list_servers_types` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `Cat` VARCHAR(255) NOT NULL,
  `Desc` TEXT NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=14 DEFAULT CHARSET=latin1;

/*Table structure for table `nq_ping_down` */

DROP TABLE IF EXISTS `nq_ping_down`;

CREATE TABLE `nq_ping_down` (
  `ID` INT(10) NOT NULL AUTO_INCREMENT,
  `SID` INT(10) DEFAULT NULL,
  `WC` INT(10) UNSIGNED NOT NULL DEFAULT '1' COMMENT 'Warning Count',
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=39537 DEFAULT CHARSET=latin1;

/*Table structure for table `port_listings` */

DROP TABLE IF EXISTS `port_listings`;

CREATE TABLE `port_listings` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `port` INT(11) DEFAULT NULL,
  `protocol` VARCHAR(50) DEFAULT 'tcp',
  `AppName_C` VARCHAR(255) DEFAULT '?',
  `AppName_R` VARCHAR(255) DEFAULT 'Unknown',
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=1394 DEFAULT CHARSET=latin1;

/*Table structure for table `port_monitoring_details` */

DROP TABLE IF EXISTS `port_monitoring_details`;

CREATE TABLE `port_monitoring_details` (
  `ID` INT(11) NOT NULL,
  `PID` INT(11) DEFAULT NULL COMMENT 'Port ID from Port_listing',
  `AppDesc` TEXT COMMENT 'Description of the application',
  `def_alert_msg` TEXT COMMENT 'Default alert message for the events',
  `std_monitor` INT(10) DEFAULT '0' COMMENT 'Make This a Default for all devices.',
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

/*Table structure for table `results_ping_raw` */

DROP TABLE IF EXISTS `results_ping_raw`;

CREATE TABLE `results_ping_raw` (
  `ID` INT(10) UNSIGNED ZEROFILL NOT NULL AUTO_INCREMENT,
  `TSID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `SIP` VARCHAR(255) NOT NULL,
  `MyBytes` INT(10) UNSIGNED NOT NULL,
  `MyTime` INT(10) UNSIGNED NOT NULL,
  `MyTTL` INT(10) UNSIGNED NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=1700493968 DEFAULT CHARSET=latin1;

/*Table structure for table `results_ping_stats` */

DROP TABLE IF EXISTS `results_ping_stats`;

CREATE TABLE `results_ping_stats` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `TSID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `Packets_Sent` INT(10) UNSIGNED NOT NULL,
  `Packets_Rec` INT(10) UNSIGNED NOT NULL,
  `Packets_Lost` INT(10) UNSIGNED NOT NULL,
  `RoundTrip_Min` INT(10) UNSIGNED NOT NULL,
  `RoundTrip_Max` INT(10) UNSIGNED NOT NULL,
  `RoundTrip_Avg` INT(10) UNSIGNED NOT NULL,
  `uptime` DOUBLE NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=170049721 DEFAULT CHARSET=latin1;

/*Table structure for table `results_port_test` */

DROP TABLE IF EXISTS `results_port_test`;

CREATE TABLE `results_port_test` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `PID` INT(10) UNSIGNED NOT NULL,
  `iSent` INT(10) UNSIGNED NOT NULL,
  `iRec` INT(10) UNSIGNED NOT NULL,
  `uptime` DOUBLE NOT NULL,
  `DTT` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  `CS` INT(10) UNSIGNED NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `results_timestamp` */

DROP TABLE IF EXISTS `results_timestamp`;

CREATE TABLE `results_timestamp` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `SID` INT(10) UNSIGNED NOT NULL,
  `DTID` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `ls` INT(10) UNSIGNED NOT NULL DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=170027921 DEFAULT CHARSET=latin1;

/*Table structure for table `results_trace` */

DROP TABLE IF EXISTS `results_trace`;

CREATE TABLE `results_trace` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `SID` INT(10) UNSIGNED NOT NULL,
  `hopno` INT(10) NOT NULL,
  `ttl` INT(10) DEFAULT NULL,
  `rtt` INT(10) DEFAULT NULL,
  `ipaddr` VARCHAR(255) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=1023829 DEFAULT CHARSET=latin1;

/*Table structure for table `self_lastrun` */

DROP TABLE IF EXISTS `self_lastrun`;

CREATE TABLE `self_lastrun` (
  `LastRun` DATETIME DEFAULT NULL
) ENGINE=MYISAM DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_daily` */

DROP TABLE IF EXISTS `uptime_stats_daily`;

CREATE TABLE `uptime_stats_daily` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `DT` DATETIME NOT NULL,
  `SID` INT(11) DEFAULT NULL,
  `uptime` DOUBLE NOT NULL DEFAULT '100',
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=1438481 DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_monthly` */

DROP TABLE IF EXISTS `uptime_stats_monthly`;

CREATE TABLE `uptime_stats_monthly` (
  `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `dt` DATETIME NOT NULL,
  `uptime` DOUBLE NOT NULL,
  `SID` INT(10) UNSIGNED NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=71220 DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_monthly_general` */

DROP TABLE IF EXISTS `uptime_stats_monthly_general`;

CREATE TABLE `uptime_stats_monthly_general` (
  `id` INT(11) NOT NULL AUTO_INCREMENT,
  `dt_m` INT(11) DEFAULT NULL,
  `dt_y` INT(11) DEFAULT NULL,
  `t_uptime` DOUBLE DEFAULT '0',
  `dtins` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`)
) ENGINE=MYISAM AUTO_INCREMENT=68 DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_weekly` */

DROP TABLE IF EXISTS `uptime_stats_weekly`;

CREATE TABLE `uptime_stats_weekly` (
  `id` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `dt_start` DATETIME NOT NULL,
  `dt_end` DATETIME NOT NULL,
  `uptime` DOUBLE NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=MYISAM DEFAULT CHARSET=latin1;

/*Table structure for table `uptime_stats_yearly` */

DROP TABLE IF EXISTS `uptime_stats_yearly`;

CREATE TABLE `uptime_stats_yearly` (
  `ID` INT(10) UNSIGNED NOT NULL AUTO_INCREMENT,
  `myyear` INT(10) UNSIGNED DEFAULT NULL,
  `uptime` DOUBLE NOT NULL,
  `SID` INT(11) UNSIGNED NOT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=MYISAM AUTO_INCREMENT=2965 DEFAULT CHARSET=latin1;

/*Table structure for table `view_active_port_list` */

DROP TABLE IF EXISTS `view_active_port_list`;

DROP VIEW IF EXISTS `view_active_port_list`;

CREATE TABLE `view_active_port_list` (
  `id` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(45) NOT NULL,
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `DisplayName` VARCHAR(45) NOT NULL,
  `PortID` INT(10) NOT NULL DEFAULT '0',
  `port` INT(10) DEFAULT NULL COMMENT 'Port Number',
  `protocol` VARCHAR(255) DEFAULT NULL COMMENT 'tcp/udp',
  `isEnabled` INT(4) DEFAULT NULL COMMENT 'Monitoring Enabled',
  `CS` INT(4) DEFAULT NULL COMMENT 'Current Status',
  `r_app_name` VARCHAR(255) NOT NULL DEFAULT ''
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_collector_list` */

DROP TABLE IF EXISTS `view_collector_list`;

DROP VIEW IF EXISTS `view_collector_list`;

CREATE TABLE `view_collector_list` (
  `ID` INT(4) NOT NULL DEFAULT '0',
  `IsBalanced` INT(4) DEFAULT '1',
  `ServerName` VARCHAR(255) DEFAULT NULL,
  `Status` VARCHAR(8) DEFAULT NULL,
  `Balanced` VARCHAR(3) DEFAULT NULL,
  `LUD` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CL` BIGINT(21) DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_monthly_gen_friendlydates` */

DROP TABLE IF EXISTS `view_monthly_gen_friendlydates`;

DROP VIEW IF EXISTS `view_monthly_gen_friendlydates`;

CREATE TABLE `view_monthly_gen_friendlydates` (
  `id` INT(11) NOT NULL DEFAULT '0',
  `dt_m` INT(11) DEFAULT NULL,
  `dt_y` INT(11) DEFAULT NULL,
  `t_uptime` DOUBLE DEFAULT '0',
  `dt` VARCHAR(69) CHARACTER SET utf8 DEFAULT NULL,
  `dtins` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `t_downtime` DECIMAL(3,3) DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_ping_timepingstats` */

DROP TABLE IF EXISTS `view_ping_timepingstats`;

DROP VIEW IF EXISTS `view_ping_timepingstats`;

CREATE TABLE `view_ping_timepingstats` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `SID` INT(10) UNSIGNED NOT NULL,
  `DTID` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `ls` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `Packets_Sent` INT(10) UNSIGNED NOT NULL,
  `Packets_Rec` INT(10) UNSIGNED NOT NULL,
  `Packets_Lost` INT(10) UNSIGNED NOT NULL,
  `RoundTrip_Min` INT(10) UNSIGNED NOT NULL,
  `RoundTrip_Max` INT(10) UNSIGNED NOT NULL,
  `RoundTrip_Avg` INT(10) UNSIGNED NOT NULL,
  `uptime` DOUBLE NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_port_to_server_appname` */

DROP TABLE IF EXISTS `view_port_to_server_appname`;

DROP VIEW IF EXISTS `view_port_to_server_appname`;

CREATE TABLE `view_port_to_server_appname` (
  `ID` INT(10) NOT NULL DEFAULT '0',
  `SID` INT(10) DEFAULT NULL COMMENT 'Machine ID',
  `DisplayName` VARCHAR(45) NOT NULL,
  `Servername` VARCHAR(45) NOT NULL,
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `Port` INT(10) DEFAULT NULL COMMENT 'Port Number',
  `protocol` VARCHAR(255) DEFAULT NULL COMMENT 'tcp/udp',
  `AppName_C` VARCHAR(255) DEFAULT NULL,
  `AppName_R` VARCHAR(255) DEFAULT NULL,
  `IsEnabled` INT(4) DEFAULT NULL COMMENT 'Monitoring Enabled',
  `CS` INT(4) DEFAULT NULL COMMENT 'Current Status'
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_all` */

DROP TABLE IF EXISTS `view_servers_all`;

DROP VIEW IF EXISTS `view_servers_all`;

CREATE TABLE `view_servers_all` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(45) NOT NULL,
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` VARCHAR(10) DEFAULT NULL,
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` VARCHAR(8) DEFAULT NULL,
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `DoPing` VARCHAR(3) DEFAULT NULL,
  `DoTrace` VARCHAR(3) DEFAULT NULL,
  `DoPort` VARCHAR(3) DEFAULT NULL,
  `DoHTTP` VARCHAR(3) DEFAULT NULL,
  `Cat` VARCHAR(255) NOT NULL,
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `PingRepeats` INT(10) DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_disabled` */

DROP TABLE IF EXISTS `view_servers_disabled`;

DROP VIEW IF EXISTS `view_servers_disabled`;

CREATE TABLE `view_servers_disabled` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(45) NOT NULL,
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` INT(10) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Current Status',
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT NULL,
  `DoTrace` INT(10) DEFAULT NULL,
  `DoPort` INT(10) DEFAULT NULL,
  `DoHTTP` INT(10) DEFAULT NULL,
  `Cat` VARCHAR(255) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_downonly` */

DROP TABLE IF EXISTS `view_servers_downonly`;

DROP VIEW IF EXISTS `view_servers_downonly`;

CREATE TABLE `view_servers_downonly` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(45) NOT NULL,
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` INT(10) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Current Status',
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT NULL,
  `DoTrace` INT(10) DEFAULT NULL,
  `DoPort` INT(10) DEFAULT NULL,
  `DoHTTP` INT(10) DEFAULT NULL,
  `Cat` VARCHAR(255) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_errorsonly` */

DROP TABLE IF EXISTS `view_servers_errorsonly`;

DROP VIEW IF EXISTS `view_servers_errorsonly`;

CREATE TABLE `view_servers_errorsonly` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(45) NOT NULL,
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` VARCHAR(17) DEFAULT NULL,
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` VARCHAR(8) DEFAULT NULL,
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT NULL,
  `DoTrace` INT(10) DEFAULT NULL,
  `DoPort` INT(10) DEFAULT NULL,
  `DoHTTP` INT(10) DEFAULT NULL,
  `Cat` VARCHAR(255) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_servers_uponly` */

DROP TABLE IF EXISTS `view_servers_uponly`;

DROP VIEW IF EXISTS `view_servers_uponly`;

CREATE TABLE `view_servers_uponly` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(45) NOT NULL,
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` INT(10) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Current Status',
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT NULL,
  `DoTrace` INT(10) DEFAULT NULL,
  `DoPort` INT(10) DEFAULT NULL,
  `DoHTTP` INT(10) DEFAULT NULL,
  `Cat` VARCHAR(255) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `view_website_list_all` */

DROP TABLE IF EXISTS `view_website_list_all`;

DROP VIEW IF EXISTS `view_website_list_all`;

CREATE TABLE `view_website_list_all` (
  `DisplayName` VARCHAR(45) NOT NULL,
  `DeviceStatus` INT(10) UNSIGNED NOT NULL DEFAULT '0' COMMENT 'Current Status',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DeviceEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ID` INT(11) NOT NULL DEFAULT '0',
  `SID` INT(11) DEFAULT NULL,
  `website_name` VARCHAR(255) DEFAULT NULL,
  `CS` INT(1) DEFAULT NULL,
  `last_responsetime` DECIMAL(10,0) DEFAULT NULL,
  `last_check` DATETIME DEFAULT NULL,
  `code_collect` INT(1) DEFAULT NULL,
  `code_compair` INT(11) DEFAULT NULL,
  `code_wordphrase` INT(11) DEFAULT NULL,
  `code_wordphrase_oper` VARCHAR(2) DEFAULT NULL,
  `code_wordphrase_txt` TEXT,
  `use_auth` INT(11) DEFAULT NULL,
  `auth_ntlm` INT(11) DEFAULT NULL,
  `auth_uid` VARCHAR(45) DEFAULT NULL,
  `auth_pwd` VARCHAR(45) DEFAULT NULL,
  `auth_domain` VARCHAR(45) DEFAULT NULL,
  `webenabled` INT(11) DEFAULT NULL,
  `sid_is_host` INT(11) DEFAULT NULL,
  `CurrentStatus` VARCHAR(13) DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_collector_list` */

DROP TABLE IF EXISTS `web_view_collector_list`;

DROP VIEW IF EXISTS `web_view_collector_list`;

CREATE TABLE `web_view_collector_list` (
  `ID` INT(4) NOT NULL DEFAULT '0',
  `IsBalanced` INT(4) DEFAULT '1',
  `ServerName` VARCHAR(255) DEFAULT NULL,
  `Status` VARCHAR(8) DEFAULT NULL,
  `Balanced` VARCHAR(3) DEFAULT NULL,
  `LUD` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CL` BIGINT(21) DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_all` */

DROP TABLE IF EXISTS `web_view_servers_all`;

DROP VIEW IF EXISTS `web_view_servers_all`;

CREATE TABLE `web_view_servers_all` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` VARCHAR(36) DEFAULT NULL,
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT NULL,
  `DoTrace` INT(10) DEFAULT NULL,
  `DoPort` INT(10) DEFAULT NULL,
  `DoHTTP` INT(10) DEFAULT NULL,
  `cat` VARCHAR(255) NOT NULL,
  `PingRepeats` INT(10) DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_disabled` */

DROP TABLE IF EXISTS `web_view_servers_disabled`;

DROP VIEW IF EXISTS `web_view_servers_disabled`;

CREATE TABLE `web_view_servers_disabled` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` VARCHAR(36) DEFAULT NULL,
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT NULL,
  `DoTrace` INT(10) DEFAULT NULL,
  `DoPort` INT(10) DEFAULT NULL,
  `DoHTTP` INT(10) DEFAULT NULL,
  `cat` VARCHAR(255) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_downonly` */

DROP TABLE IF EXISTS `web_view_servers_downonly`;

DROP VIEW IF EXISTS `web_view_servers_downonly`;

CREATE TABLE `web_view_servers_downonly` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` VARCHAR(36) DEFAULT NULL,
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT NULL,
  `DoTrace` INT(10) DEFAULT NULL,
  `DoPort` INT(10) DEFAULT NULL,
  `DoHTTP` INT(10) DEFAULT NULL,
  `cat` VARCHAR(255) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_errorsonly` */

DROP TABLE IF EXISTS `web_view_servers_errorsonly`;

DROP VIEW IF EXISTS `web_view_servers_errorsonly`;

CREATE TABLE `web_view_servers_errorsonly` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CSText` VARCHAR(10) DEFAULT NULL,
  `CS` VARCHAR(36) DEFAULT NULL,
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT NULL,
  `DoTrace` INT(10) DEFAULT NULL,
  `DoPort` INT(10) DEFAULT NULL,
  `DoHTTP` INT(10) DEFAULT NULL,
  `cat` VARCHAR(255) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_ports` */

DROP TABLE IF EXISTS `web_view_servers_ports`;

DROP VIEW IF EXISTS `web_view_servers_ports`;

CREATE TABLE `web_view_servers_ports` (
  `ID` INT(10) NOT NULL DEFAULT '0',
  `SID` INT(10) DEFAULT NULL COMMENT 'Machine ID',
  `Port` INT(10) DEFAULT NULL COMMENT 'Port Number',
  `protocol` VARCHAR(255) DEFAULT NULL COMMENT 'tcp/udp',
  `IsEnabled` INT(4) DEFAULT NULL COMMENT 'Monitoring Enabled',
  `IsMonitored` VARCHAR(3) DEFAULT NULL,
  `CS` INT(4) DEFAULT NULL COMMENT 'Current Status',
  `CurrentStatus` VARCHAR(4) DEFAULT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `web_view_servers_uponly` */

DROP TABLE IF EXISTS `web_view_servers_uponly`;

DROP VIEW IF EXISTS `web_view_servers_uponly`;

CREATE TABLE `web_view_servers_uponly` (
  `ID` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `ServerName` VARCHAR(255) CHARACTER SET utf8 NOT NULL DEFAULT '',
  `ServerIPAddress` VARCHAR(255) NOT NULL,
  `CS` VARCHAR(36) DEFAULT NULL,
  `DisplayName` VARCHAR(45) NOT NULL,
  `IsEnabled` INT(10) UNSIGNED NOT NULL DEFAULT '0',
  `DTAdded` TIMESTAMP NOT NULL DEFAULT '0000-00-00 00:00:00',
  `CID` INT(10) DEFAULT NULL COMMENT 'Collector ID, 0=All',
  `DoPing` INT(10) DEFAULT NULL,
  `DoTrace` INT(10) DEFAULT NULL,
  `DoPort` INT(10) DEFAULT NULL,
  `DoHTTP` INT(10) DEFAULT NULL,
  `cat` VARCHAR(255) NOT NULL
) ENGINE=INNODB DEFAULT CHARSET=latin1;

/*Table structure for table `website_check_results` */

DROP TABLE IF EXISTS `website_check_results`;

CREATE TABLE `website_check_results` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SID` INT(11) DEFAULT NULL,
  `WID` INT(11) DEFAULT NULL,
  `DTID` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  `ls` INT(11) DEFAULT NULL,
  `responsetime` VARCHAR(45) DEFAULT NULL,
  `error_msg` TEXT,
  `code_match` INT(11) DEFAULT '1',
  `word_match` INT(11) DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=INNODB AUTO_INCREMENT=9 DEFAULT CHARSET=latin1;

/*Table structure for table `website_code` */

DROP TABLE IF EXISTS `website_code`;

CREATE TABLE `website_code` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `WID` INT(11) DEFAULT NULL,
  `site_code` TEXT,
  `site_code_lup` DATETIME DEFAULT NULL,
  `dtins` TIMESTAMP NULL DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`ID`)
) ENGINE=INNODB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;

/*Table structure for table `website_list` */

DROP TABLE IF EXISTS `website_list`;

CREATE TABLE `website_list` (
  `ID` INT(11) NOT NULL AUTO_INCREMENT,
  `SID` INT(11) DEFAULT NULL,
  `website_name` VARCHAR(255) DEFAULT NULL,
  `CS` INT(1) DEFAULT NULL,
  `sid_is_host` INT(11) DEFAULT '1',
  `last_responsetime` DECIMAL(10,0) DEFAULT NULL,
  `last_check` DATETIME DEFAULT NULL,
  `code_collect` INT(1) DEFAULT '1',
  `code_compair` INT(11) DEFAULT '0',
  `code_wordphrase` INT(11) DEFAULT '0',
  `code_wordphrase_oper` VARCHAR(2) DEFAULT '=',
  `code_wordphrase_txt` TEXT,
  `use_auth` INT(11) DEFAULT '0',
  `auth_ntlm` INT(11) DEFAULT '0',
  `auth_uid` VARCHAR(45) DEFAULT NULL,
  `auth_pwd` VARCHAR(45) DEFAULT NULL,
  `auth_domain` VARCHAR(45) DEFAULT NULL,
  `isenabled` INT(11) DEFAULT '1',
  PRIMARY KEY (`ID`)
) ENGINE=INNODB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1 ROW_FORMAT=DYNAMIC;

/*View structure for view view_active_port_list */

DROP VIEW IF EXISTS `view_active_port_list`;

DROP TABLE IF EXISTS `view_active_port_list`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_active_port_list` AS (SELECT `ls`.`ID` AS `id`,`ls`.`ServerName` AS `ServerName`,`ls`.`ServerIPAddress` AS `ServerIPAddress`,`ls`.`DisplayName` AS `DisplayName`,`p`.`ID` AS `PortID`,`p`.`Port` AS `port`,`p`.`protocol` AS `protocol`,`p`.`IsEnabled` AS `isEnabled`,`p`.`CS` AS `CS`,`p`.`r_app_name` AS `r_app_name` FROM (`list_servers` `ls` JOIN `list_servers_ports` `p` ON((`p`.`SID` = `ls`.`ID`))) WHERE ((`ls`.`IsEnabled` = 1) AND (`ls`.`DoPort` = 1) AND (`ls`.`CS` = 1) AND (`p`.`IsEnabled` = 1)) ORDER BY `ls`.`ServerName`);

/*View structure for view view_collector_list */

DROP VIEW IF EXISTS `view_collector_list`;

DROP TABLE IF EXISTS `view_collector_list`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_collector_list` AS (SELECT `list_collectors`.`ID` AS `ID`,`list_collectors`.`IsBalanced` AS `IsBalanced`,`list_collectors`.`ServerName` AS `ServerName`,(CASE `list_collectors`.`IsEnabled` WHEN 0 THEN _latin1'Disabled' WHEN 1 THEN _latin1'Enabled' END) AS `Status`,(CASE `list_collectors`.`IsBalanced` WHEN 0 THEN _latin1'No' WHEN 1 THEN _latin1'Yes' END) AS `Balanced`,`list_collectors`.`LUD` AS `LUD`,(SELECT COUNT(0) AS `Count(*)` FROM `list_servers` `ls` WHERE ((`ls`.`CID` = `list_collectors`.`ID`) AND (`ls`.`CS` <> 5))) AS `CL` FROM `list_collectors`);

/*View structure for view view_monthly_gen_friendlydates */

DROP VIEW IF EXISTS `view_monthly_gen_friendlydates`;

DROP TABLE IF EXISTS `view_monthly_gen_friendlydates`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_monthly_gen_friendlydates` AS SELECT `uptime_stats_monthly_general`.`id` AS `id`,`uptime_stats_monthly_general`.`dt_m` AS `dt_m`,`uptime_stats_monthly_general`.`dt_y` AS `dt_y`,`uptime_stats_monthly_general`.`t_uptime` AS `t_uptime`,DATE_FORMAT(CONCAT(`uptime_stats_monthly_general`.`dt_y`,'-',`uptime_stats_monthly_general`.`dt_m`,'-01'),'%M %Y') AS `dt`,`uptime_stats_monthly_general`.`dtins` AS `dtins`,CAST(CONCAT((100 - `uptime_stats_monthly_general`.`t_uptime`)) AS DECIMAL(3,3)) AS `t_downtime` FROM `uptime_stats_monthly_general` ORDER BY `uptime_stats_monthly_general`.`dtins` DESC LIMIT 0,6;

/*View structure for view view_ping_timepingstats */

DROP VIEW IF EXISTS `view_ping_timepingstats`;

DROP TABLE IF EXISTS `view_ping_timepingstats`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_ping_timepingstats` AS (SELECT `results_timestamp`.`ID` AS `ID`,`results_timestamp`.`SID` AS `SID`,`results_timestamp`.`DTID` AS `DTID`,`results_timestamp`.`ls` AS `ls`,`results_ping_stats`.`Packets_Sent` AS `Packets_Sent`,`results_ping_stats`.`Packets_Rec` AS `Packets_Rec`,`results_ping_stats`.`Packets_Lost` AS `Packets_Lost`,`results_ping_stats`.`RoundTrip_Min` AS `RoundTrip_Min`,`results_ping_stats`.`RoundTrip_Max` AS `RoundTrip_Max`,`results_ping_stats`.`RoundTrip_Avg` AS `RoundTrip_Avg`,`results_ping_stats`.`uptime` AS `uptime` FROM (`results_timestamp` JOIN `results_ping_stats` ON((`results_timestamp`.`ID` = `results_ping_stats`.`TSID`))) ORDER BY `results_timestamp`.`DTID` DESC);

/*View structure for view view_port_to_server_appname */

DROP VIEW IF EXISTS `view_port_to_server_appname`;

DROP TABLE IF EXISTS `view_port_to_server_appname`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_port_to_server_appname` AS (SELECT `lsp`.`ID` AS `ID`,`lsp`.`SID` AS `SID`,`ls`.`DisplayName` AS `DisplayName`,`ls`.`ServerName` AS `Servername`,`ls`.`ServerIPAddress` AS `ServerIPAddress`,`lsp`.`Port` AS `Port`,`lsp`.`protocol` AS `protocol`,`pl`.`AppName_C` AS `AppName_C`,`pl`.`AppName_R` AS `AppName_R`,`lsp`.`IsEnabled` AS `IsEnabled`,`lsp`.`CS` AS `CS` FROM ((`list_servers_ports` `lsp` JOIN `list_servers` `ls` ON((`ls`.`ID` = `lsp`.`SID`))) JOIN `port_listings` `pl` ON((`pl`.`port` = `lsp`.`Port`))));

/*View structure for view view_servers_all */

DROP VIEW IF EXISTS `view_servers_all`;

DROP TABLE IF EXISTS `view_servers_all`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_servers_all` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then _latin1'Down' when 1 then _latin1'Up' when 2 then _latin1'IP Changed' when 3 then _latin1'Disabled' when 4 then _latin1'Slow' when 5 then _latin1'Deleted' end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,(case `list_servers`.`IsEnabled` when 0 then _latin1'Disabled' when 1 then _latin1'Enabled' end) AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,(case `list_servers`.`DoPing` when 0 then _latin1'No' when 1 then _latin1'Yes' end) AS `DoPing`,(case `list_servers`.`DoTrace` when 0 then _latin1'No' when 1 then _latin1'Yes' end) AS `DoTrace`,(case `list_servers`.`DoPort` when 0 then _latin1'No' when 1 then _latin1'Yes' end) AS `DoPort`,(case `list_servers`.`DoHTTP` when 0 then _latin1'No' when 1 then _latin1'Yes' end) AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat`,`list_servers`.`CID` AS `CID`,`list_servers`.`PingRepeats` AS `PingRepeats` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))));

/*View structure for view view_servers_disabled */

DROP VIEW IF EXISTS `view_servers_disabled`;

DROP TABLE IF EXISTS `view_servers_disabled`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_servers_disabled` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,`list_servers`.`CS` AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))) where ((`list_servers`.`IsEnabled` = 0) and (`list_servers`.`CS` <> 5)) order by `list_servers`.`ServerName`);

/*View structure for view view_servers_downonly */

DROP VIEW IF EXISTS `view_servers_downonly`;

DROP TABLE IF EXISTS `view_servers_downonly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_servers_downonly` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,`list_servers`.`CS` AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))) where ((`list_servers`.`CS` = 0) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view view_servers_errorsonly */

DROP VIEW IF EXISTS `view_servers_errorsonly`;

DROP TABLE IF EXISTS `view_servers_errorsonly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_servers_errorsonly` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then _latin1'Down' when 1 then _latin1'Up' when 2 then _latin1'IP Changed' when 3 then _latin1'Disabled' when 4 then _latin1'Slow' when 5 then _latin1'Deleted' when 6 then _latin1'Port Down' when 7 then _latin1'WebSite Down' when 8 then _latin1'Web Search Failed' when 9 then _latin1'Web Code Failed' when 10 then _latin1'Web Tests Failed' end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,(case `list_servers`.`IsEnabled` when 0 then _latin1'Disabled' when 1 then _latin1'Enabled' end) AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))) where ((`list_servers`.`CS` <> 1) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view view_servers_uponly */

DROP VIEW IF EXISTS `view_servers_uponly`;

DROP TABLE IF EXISTS `view_servers_uponly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_servers_uponly` AS (select `list_servers`.`ID` AS `ID`,`list_servers`.`ServerName` AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,`list_servers`.`CS` AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`list_servers_types`.`Cat` AS `Cat` from (`list_servers` join `list_servers_types` on((`list_servers`.`TID` = `list_servers_types`.`ID`))) where ((`list_servers`.`CS` = 1) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view view_website_list_all */

DROP VIEW IF EXISTS `view_website_list_all`;

DROP TABLE IF EXISTS `view_website_list_all`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `view_website_list_all` AS (select `ls`.`DisplayName` AS `DisplayName`,`ls`.`CS` AS `DeviceStatus`,`ls`.`CID` AS `CID`,`ls`.`IsEnabled` AS `DeviceEnabled`,`wl`.`ID` AS `ID`,`wl`.`SID` AS `SID`,`wl`.`website_name` AS `website_name`,`wl`.`CS` AS `CS`,`wl`.`last_responsetime` AS `last_responsetime`,`wl`.`last_check` AS `last_check`,`wl`.`code_collect` AS `code_collect`,`wl`.`code_compair` AS `code_compair`,`wl`.`code_wordphrase` AS `code_wordphrase`,`wl`.`code_wordphrase_oper` AS `code_wordphrase_oper`,`wl`.`code_wordphrase_txt` AS `code_wordphrase_txt`,`wl`.`use_auth` AS `use_auth`,`wl`.`auth_ntlm` AS `auth_ntlm`,`wl`.`auth_uid` AS `auth_uid`,`wl`.`auth_pwd` AS `auth_pwd`,`wl`.`auth_domain` AS `auth_domain`,`wl`.`isenabled` AS `webenabled`,`wl`.`sid_is_host` AS `sid_is_host`,(case `wl`.`CS` when 0 then _latin1'Down' when 1 then _latin1'Up' when 2 then _latin1'Code Changed' when 3 then _latin1'Disabled' when 4 then _latin1'Slow' when 5 then _latin1'Deleted' when 6 then _latin1'Phrase Failed' when 7 then _latin1'Host Down' end) AS `CurrentStatus` from (`list_servers` `ls` join `website_list` `wl` on((`wl`.`SID` = `ls`.`ID`))) where (`ls`.`DoHTTP` = 1));

/*View structure for view web_view_collector_list */

DROP VIEW IF EXISTS `web_view_collector_list`;

DROP TABLE IF EXISTS `web_view_collector_list`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `web_view_collector_list` AS (select `list_collectors`.`ID` AS `ID`,`list_collectors`.`IsBalanced` AS `IsBalanced`,`list_collectors`.`ServerName` AS `ServerName`,(case `list_collectors`.`IsEnabled` when 0 then _latin1'Disabled' when 1 then _latin1'Enabled' end) AS `Status`,(case `list_collectors`.`IsBalanced` when 0 then _latin1'No' when 1 then _latin1'Yes' end) AS `Balanced`,`list_collectors`.`LUD` AS `LUD`,(select count(0) AS `Count(*)` from `list_servers` `ls` where ((`ls`.`CID` = `list_collectors`.`ID`) and (`ls`.`CS` <> 5))) AS `CL` from `list_collectors`);

/*View structure for view web_view_servers_all */

DROP VIEW IF EXISTS `web_view_servers_all`;

DROP TABLE IF EXISTS `web_view_servers_all`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `web_view_servers_all` AS (select `list_servers`.`ID` AS `ID`,cast(concat('<a href="View_Device_Details.aspx?id=',concat(`list_servers`.`ID`),_utf8'">',`list_servers`.`ServerName`,'</a>') as char(255) charset utf8) AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif"') when 1 then concat(_latin1'<img src="images/up.gif"') when 2 then concat(_latin1'<img src="images/warn.gif"') when 3 then concat(_latin1'<img src="images/disabled.gif"') when 4 then concat(_latin1'<img src="images/warn.gif"') when 5 then concat(_latin1'<img src="images/event_error_sm.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`lst`.`Cat` AS `cat`,`list_servers`.`PingRepeats` AS `PingRepeats` from (`list_servers` join `list_servers_types` `lst` on((`lst`.`ID` = `list_servers`.`TID`))) order by `list_servers`.`ServerName`);

/*View structure for view web_view_servers_disabled */

DROP VIEW IF EXISTS `web_view_servers_disabled`;

DROP TABLE IF EXISTS `web_view_servers_disabled`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `web_view_servers_disabled` AS (select `list_servers`.`ID` AS `ID`,cast(concat('<a href="View_Device_Details.aspx?id=',concat(`list_servers`.`ID`),_utf8'">',`list_servers`.`ServerName`,'</a>') as char(255) charset utf8) AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif"') when 1 then concat(_latin1'<img src="images/up.gif"') when 2 then concat(_latin1'<img src="images/warn.gif"') when 3 then concat(_latin1'<img src="images/disabled.gif"') when 4 then concat(_latin1'<img src="images/warn.gif"') when 5 then concat(_latin1'<img src="images/event_error_sm.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`lst`.`Cat` AS `cat` from (`list_servers` join `list_servers_types` `lst` on((`lst`.`ID` = `list_servers`.`TID`))) where (`list_servers`.`IsEnabled` = 0) order by `list_servers`.`ServerName`);

/*View structure for view web_view_servers_downonly */

DROP VIEW IF EXISTS `web_view_servers_downonly`;

DROP TABLE IF EXISTS `web_view_servers_downonly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `web_view_servers_downonly` AS (select `list_servers`.`ID` AS `ID`,cast(concat('<a href="View_Device_Details.aspx?id=',concat(`list_servers`.`ID`),_utf8'">',`list_servers`.`ServerName`,'</a>') as char(255) charset utf8) AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif">') when 1 then concat(_latin1'<img src="images/up.gif>"') when 2 then concat(_latin1'<img src="images/warn.gif>"') when 3 then concat(_latin1'<img src="images/disabled.gif>"') when 4 then concat(_latin1'<img src="images/warn.gif>"') when 5 then concat(_latin1'<img src="images/event_error_sm.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`lst`.`Cat` AS `cat` from (`list_servers` join `list_servers_types` `lst` on((`lst`.`ID` = `list_servers`.`TID`))) where ((`list_servers`.`CS` = 0) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view web_view_servers_errorsonly */

DROP VIEW IF EXISTS `web_view_servers_errorsonly`;

DROP TABLE IF EXISTS `web_view_servers_errorsonly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `web_view_servers_errorsonly` AS (select `list_servers`.`ID` AS `ID`,cast(concat('<a href="View_Device_Details.aspx?id=',concat(`list_servers`.`ID`),_utf8'">',`list_servers`.`ServerName`,'</a>') as char(255) charset utf8) AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then _latin1'Down' when 1 then _latin1'Up' when 2 then _latin1'IP Changed' when 3 then _latin1'Disabled' when 4 then _latin1'Slow' when 5 then _latin1'Deleted' end) AS `CSText`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif"') when 1 then concat(_latin1'<img src="images/up.gif"') when 2 then concat(_latin1'<img src="images/warn.gif"') when 3 then concat(_latin1'<img src="images/disabled.gif"') when 4 then concat(_latin1'<img src="images/warn.gif"') when 5 then concat(_latin1'<img src="images/event_error_sm.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`lst`.`Cat` AS `cat` from (`list_servers` join `list_servers_types` `lst` on((`lst`.`ID` = `list_servers`.`TID`))) where ((`list_servers`.`CS` <> 1) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/*View structure for view web_view_servers_ports */

DROP VIEW IF EXISTS `web_view_servers_ports`;

DROP TABLE IF EXISTS `web_view_servers_ports`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `web_view_servers_ports` AS (select `list_servers_ports`.`ID` AS `ID`,`list_servers_ports`.`SID` AS `SID`,`list_servers_ports`.`Port` AS `Port`,`list_servers_ports`.`protocol` AS `protocol`,`list_servers_ports`.`IsEnabled` AS `IsEnabled`,(case `list_servers_ports`.`IsEnabled` when 0 then 'No' when 1 then 'Yes' end) AS `IsMonitored`,`list_servers_ports`.`CS` AS `CS`,(case `list_servers_ports`.`CS` when 1 then 'UP' when 0 then 'DOWN' end) AS `CurrentStatus` from `list_servers_ports`);

/*View structure for view web_view_servers_uponly */

DROP VIEW IF EXISTS `web_view_servers_uponly`;

DROP TABLE IF EXISTS `web_view_servers_uponly`;

CREATE ALGORITHM=UNDEFINED DEFINER=`bssm`@`%` SQL SECURITY DEFINER VIEW `web_view_servers_uponly` AS (select `list_servers`.`ID` AS `ID`,cast(concat('<a href="View_Device_Details.aspx?id=',concat(`list_servers`.`ID`),_utf8'">',`list_servers`.`ServerName`,'</a>') as char(255) charset utf8) AS `ServerName`,`list_servers`.`ServerIPAddress` AS `ServerIPAddress`,(case `list_servers`.`CS` when 0 then concat(_latin1'<img src="images/down.gif"') when 1 then concat(_latin1'<img src="images/up.gif"') when 2 then concat(_latin1'<img src="images/warn.gif"') when 3 then concat(_latin1'<img src="images/disabled.gif"') when 4 then concat(_latin1'<img src="images/warn.gif"') when 5 then concat(_latin1'<img src="images/event_error_sm.gif"') end) AS `CS`,`list_servers`.`DisplayName` AS `DisplayName`,`list_servers`.`IsEnabled` AS `IsEnabled`,`list_servers`.`DTAdded` AS `DTAdded`,`list_servers`.`CID` AS `CID`,`list_servers`.`DoPing` AS `DoPing`,`list_servers`.`DoTrace` AS `DoTrace`,`list_servers`.`DoPort` AS `DoPort`,`list_servers`.`DoHTTP` AS `DoHTTP`,`lst`.`Cat` AS `cat` from (`list_servers` join `list_servers_types` `lst` on((`lst`.`ID` = `list_servers`.`TID`))) where ((`list_servers`.`CS` = 1) and (`list_servers`.`IsEnabled` = 1)) order by `list_servers`.`ServerName`);

/* Procedure structure for procedure `sp_mnt_pingdata` */

drop procedure if exists `sp_mnt_pingdata`;

DELIMITER $$

CREATE DEFINER=`bssm`@`%` PROCEDURE `sp_mnt_pingdata`(iday int)
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare ReqID int;
	DECLARE RID CURSOR FOR select ID from results_timestamp where DTID < adddate(CURRENT_TIMESTAMP, INTERVAL -iDay DAY);
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
	Open RID;
	REPEAT
		FETCH RID INTO ReqID;
		IF NOT done THEN
			delete from results_ping_raw where TSID=ReqID;
			delete from results_ping_stats where TSID=ReqID;
			delete from results_timestamp where ID=ReqID;
		END IF;
	UNTIL done END REPEAT;
	Close RID;
    END$$

DELIMITER ;

/* Procedure structure for procedure `sp_mnt_pingdata_hrs` */

drop procedure if exists `sp_mnt_pingdata_hrs`;

DELIMITER $$

CREATE DEFINER=`bssm`@`%` PROCEDURE `sp_mnt_pingdata_hrs`(ihrs int)
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare ReqID int;
	DECLARE RID CURSOR FOR select ID from results_timestamp where DTID < adddate(CURRENT_TIMESTAMP, INTERVAL -ihrs HOUR);
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
	Open RID;
	REPEAT
		FETCH RID INTO ReqID;
		IF NOT done THEN
			delete from results_ping_raw where TSID=ReqID;
			delete from results_ping_stats where TSID=ReqID;
			delete from results_timestamp where ID=ReqID;
		END IF;
	UNTIL done END REPEAT;
	Close RID;
    END$$

DELIMITER ;

/* Procedure structure for procedure `sp_mnt_rawpingdata_day` */

drop procedure if exists `sp_mnt_rawpingdata_day`;

DELIMITER $$

CREATE DEFINER=`bssm`@`%` PROCEDURE `sp_mnt_rawpingdata_day`()
BEGIN

  DECLARE done INT DEFAULT 0;

	Declare ReqID int;

	DECLARE RID CURSOR FOR select ID from view_ping_timepingstats where DTID < adddate(CURRENT_TIMESTAMP, INTERVAL -iDay DAY);

	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;

	Open RID;

	REPEAT

		FETCH RID INTO ReqID;

		IF NOT done THEN

			delete from results_ping_raw where TSID=ReqID;

		END IF;

	UNTIL done END REPEAT;

	Close RID;

END$$

DELIMITER ;

/* Procedure structure for procedure `sp_mnt_rawpingdata_hrs` */

drop procedure if exists `sp_mnt_rawpingdata_hrs`;

DELIMITER $$

CREATE DEFINER=`bssm`@`%` PROCEDURE `sp_mnt_rawpingdata_hrs`(ihrs int)
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare ReqID int;
	DECLARE RID CURSOR FOR select ID from results_timestamp where DTID < adddate(CURRENT_TIMESTAMP, INTERVAL -ihrs HOUR);
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
	Open RID;
	REPEAT
		FETCH RID INTO ReqID;
		IF NOT done THEN
			delete from results_ping_raw where TSID=ReqID;
		END IF;
	UNTIL done END REPEAT;
	Close RID;
    END$$

DELIMITER ;

/* Procedure structure for procedure `sp_mnt_rawpingdata_min` */

drop procedure if exists `sp_mnt_rawpingdata_min`;

DELIMITER $$

CREATE DEFINER=`bssm`@`%` PROCEDURE `sp_mnt_rawpingdata_min`(imin int)
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare ReqID int;
	DECLARE RID CURSOR FOR select ID from results_timestamp where DTID < adddate(CURRENT_TIMESTAMP, INTERVAL -imin MINUTE);
	DECLARE CONTINUE HANDLER FOR NOT FOUND SET done = 1;
	Open RID;
	REPEAT
		FETCH RID INTO ReqID;
		IF NOT done THEN
			delete from results_ping_raw where TSID=ReqID;
		END IF;
	UNTIL done END REPEAT;
	Close RID;
    END$$

DELIMITER ;

/* Procedure structure for procedure `sp_server_delete` */

drop procedure if exists `sp_server_delete`;

DELIMITER $$

CREATE DEFINER=`bssm`@`%` PROCEDURE `sp_server_delete`(MSID int)
BEGIN
	DECLARE done INT DEFAULT 0;
	Declare ResID int;
	DECLARE PINGSTATS CURSOR FOR select ID from results_timestamp where SID=MSID;
	DECLARE CONTINUE HANDLER FOR SQLSTATE '02000' SET done = 1;
	delete from list_servers_ports where SID=MSID;
	delete from results_trace where SID=MSID;
	delete from events_general where SID=MSID;
	Open PINGSTATS;
	REPEAT
		FETCH PINGSTATS INTO ResID;
		Delete from results_ping_raw where TSID=ResID;
		Delete from results_ping_stats where TSID=ResID;
		DELETE from results_timestamp where ID=ResID;
	UNTIL done END REPEAT;
	Close PINGSTATS;
	Delete from list_servers where ID=MSID;
    END$$

DELIMITER ;

SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
